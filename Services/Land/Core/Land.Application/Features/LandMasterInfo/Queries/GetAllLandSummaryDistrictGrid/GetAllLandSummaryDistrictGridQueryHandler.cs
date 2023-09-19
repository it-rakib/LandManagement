using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictGrid
{
    public class GetAllLandSummaryDistrictGridQueryHandler : IRequestHandler<GetAllLandSummaryDistrictGridQuery, GridEntity<GetAllLandSummaryDistrictGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryDistrictGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryDistrictGridVm>> Handle(GetAllLandSummaryDistrictGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryDistrictGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
