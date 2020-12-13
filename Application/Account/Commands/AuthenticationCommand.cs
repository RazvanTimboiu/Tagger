using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Configuration;
using Application.Common.Exceptions;
using Application.Common.Helper;
using Application.DTO;
using Persistence.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Account.Commands
{
    public class AuthenticationCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, User>
    {
        private IAccountRepository repository;
        private IMapper mapper;
        private TokenConfig tokenConfig;

        public AuthenticationCommandHandler(IAccountRepository repository, IMapper mapper, IOptions<TokenConfig> tokenConfig)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.tokenConfig = tokenConfig.Value;
        }

        private string CreateToken(Domain.Entities.Account user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.Secret));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<User> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            var account = await repository.GetAccountByUsername(request.Username, cancellationToken);
            if (account == null || StringEncoder.EncodeToBase64String(request.Password) != account.Password )
                throw new AuthenticationException("Credentials do not match any account !");

            var user = mapper.Map<User>(account);
            user.Token = CreateToken(account);

            return user;
        }
    }
}
