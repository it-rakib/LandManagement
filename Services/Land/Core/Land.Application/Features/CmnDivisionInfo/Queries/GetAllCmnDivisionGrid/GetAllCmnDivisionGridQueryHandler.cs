using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionGrid
{
    public class GetAllCmnDivisionGridQueryHandler : IRequestHandler<GetAllCmnDivisionGridQuery, GridEntity<GetAllCmnDivisionGridVM>>
    {
        private readonly ICmnDivisionRepository _cmnDivisionRepository;

        public GetAllCmnDivisionGridQueryHandler(ICmnDivisionRepository cmnDivisionRepository)
        {
            _cmnDivisionRepository = cmnDivisionRepository ?? throw new ArgumentNullException(nameof(cmnDivisionRepository));
        }

        public async Task<GridEntity<GetAllCmnDivisionGridVM>> Handle(GetAllCmnDivisionGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cmnDivisionRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
