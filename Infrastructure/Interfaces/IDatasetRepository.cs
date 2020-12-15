using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Interfaces
{
    public interface IDatasetRepository
    {
        Task<List<Dataset>> GetAll(CancellationToken cancellationToken);
        Task<List<Dataset>> GetById(int id, CancellationToken cancellationToken);
    }
}
