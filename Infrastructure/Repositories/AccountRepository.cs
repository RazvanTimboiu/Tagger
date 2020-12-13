using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence.Repositories
{
    public class AccountRepository : Repository, IAccountRepository
    {
        public AccountRepository(ITaggerDbContext context) : base(context)
        {

        }

        public Task<Account> GetAccountByUsername(string username, CancellationToken cancellationToken)
        {
            return Context.Accounts.FirstOrDefaultAsync(acc => acc.Username == username, cancellationToken);
        }


    }
}
