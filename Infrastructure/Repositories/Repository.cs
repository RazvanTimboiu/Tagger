using Persistence.Interfaces;

namespace Persistence.Repositories
{
    public class Repository
    {
        protected readonly ITaggerDbContext Context;

        public Repository(ITaggerDbContext context)
        {
            Context = context;
        }
    }
}
