using Application.Account.Commands;
using Application.Common.Exceptions;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tagger.Controllers
{
    public class AccountController:BaseController
    {

        [HttpPost("accounts/login")]
        public async Task<ActionResult<User>> Authenticate(AuthenticationCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return Ok(result);

            }
            catch (AuthenticationException e )
            {
                return Unauthorized(e.Message);
            }
            
        }

    }
}
