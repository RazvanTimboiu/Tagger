using Domain.Entities;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class DatasetRepository : Repository, IDatasetRepository
    {
        public DatasetRepository(ITaggerDbContext context) : base(context)
        {

        }

        public Task<List<Dataset>> GetAll(CancellationToken cancellationToken)
        {
            return Context.DataSets.ToListAsync(cancellationToken);
        }

        public Task<List<Dataset>> GetById(int id, CancellationToken cancellationToken)
        {
            return Context.DataSets
                .Include(ds => ds.Creator)
                .Where(ds => ds.Creator.Id == id)
                .Include(ds => ds.Samples)
                .Include(ds => ds.Classes)
                .ToListAsync(cancellationToken);
        }

    }
}
