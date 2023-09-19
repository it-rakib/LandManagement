using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeGrid
{
    public class GetAllCmnSubRegOfficeGridQueryHandler : IRequestHandler<GetAllCmnSubRegOfficeGridQuery, GridEntity<CmnSubRegOfficeGridVM>>
    {
        private readonly ICmnSubRegOfficeRepository _cmnSubRegOfficeRepository;

        public GetAllCmnSubRegOfficeGridQueryHandler(ICmnSubRegOfficeRepository cmnSubRegOfficeRepository)
        {
            _cmnSubRegOfficeRepository = cmnSubRegOfficeRepository ?? throw new ArgumentNullException(nameof(cmnSubRegOfficeRepository));
        }

        public async Task<GridEntity<CmnSubRegOfficeGridVM>> Handle(GetAllCmnSubRegOfficeGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cmnSubRegOfficeRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
