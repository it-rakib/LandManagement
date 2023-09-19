using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationGrid
{
    public class GetAllFileLocationGridQueryHandler : IRequestHandler<GetAllFileLocationGridQuery, GridEntity<FileLocationGridVm>>
    {
        private readonly IFileLocationRepository _fileLocationRepository;

        public GetAllFileLocationGridQueryHandler(IFileLocationRepository fileLocationRepository)
        {
            _fileLocationRepository = fileLocationRepository ?? throw new ArgumentNullException(nameof(fileLocationRepository));
        }

        public async Task<GridEntity<FileLocationGridVm>> Handle(GetAllFileLocationGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _fileLocationRepository.GetAllPagingAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
