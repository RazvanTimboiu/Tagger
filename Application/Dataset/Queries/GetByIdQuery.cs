using Application.Common.DTO;
using MediatR;
using Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Dataset.Queries
{
    public class GetByIdQuery: IRequest<List<DatasetInfo>>
    {
        public int DatasetId { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, List<DatasetInfo>>
    {
        private IDatasetRepository repository;


        public GetByIdQueryHandler(IDatasetRepository repository)
        {
            this.repository = repository;
        }


        public async Task<List<DatasetInfo>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var datasets = await repository.GetById(request.DatasetId, cancellationToken);
            List<DatasetInfo> details = new List<DatasetInfo>();
            foreach(var ds in datasets)
            {
                var datasetId = ds.Id;
                var dataType = ds.DataType;
                var name = ds.Name;
                var author = ds.Creator.Username;
                var tagType = ds.TagType;
                var noOfClasses = ds.Classes.Count;
                var noOfSamples = ds.Samples.Count;

                details.Add(new DatasetInfo(datasetId, dataType, name, author, tagType, noOfClasses, noOfSamples));
                
            }

            return details;
        }
    }
}
