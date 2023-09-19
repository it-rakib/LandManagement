using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDistrictId
{
    public class GetLandSummaryByDistrictIdQueryHandler : IRequestHandler<GetLandSummaryByDistrictIdQuery,GridEntity<GetLandSummaryByDistrictIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetLandSummaryByDistrictIdQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetLandSummaryByDistrictIdVm>> Handle(GetLandSummaryByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _landMasterRepository.GetAllLandSummaryByDistrictIdGridAsync(request.options,request.DistrictId);
            return list;
        }
    }
}
