using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IAccountRepository
    {

        Task<Account>GetAccountByUsername(string username, CancellationToken cancellationToken);

    }
}
