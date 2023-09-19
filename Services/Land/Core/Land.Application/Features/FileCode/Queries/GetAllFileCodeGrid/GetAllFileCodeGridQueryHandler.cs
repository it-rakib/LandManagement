using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileCode.Queries.GetAllFileCodeGrid
{
    public class GetAllFileCodeGridQueryHandler : IRequestHandler<GetAllFileCodeGridQuery,GridEntity<GetAllFileCodeGridVm>>
    {
        private readonly IFileCodeRepository _fileCodeRepository;

        public GetAllFileCodeGridQueryHandler(IFileCodeRepository fileCodeRepository)
        {
            _fileCodeRepository = fileCodeRepository ?? throw new ArgumentNullException(nameof(fileCodeRepository));
        }

        public async Task<GridEntity<GetAllFileCodeGridVm>> Handle(GetAllFileCodeGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _fileCodeRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
