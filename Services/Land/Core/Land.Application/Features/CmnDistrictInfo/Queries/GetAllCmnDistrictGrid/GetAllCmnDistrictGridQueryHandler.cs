using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictGrid
{
    public class GetAllCmnDistrictGridQueryHandler : IRequestHandler<GetAllCmnDistrictGridQuery, GridEntity<CmnDistrictGridVM>>
    {
        private readonly ICmnDistrictRepository _cmnDistrictRepository;

        public GetAllCmnDistrictGridQueryHandler(ICmnDistrictRepository cmnDistrictRepository)
        {
            _cmnDistrictRepository = cmnDistrictRepository ?? throw new ArgumentNullException(nameof(cmnDistrictRepository));
        }

        public async Task<GridEntity<CmnDistrictGridVM>> Handle(GetAllCmnDistrictGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cmnDistrictRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
