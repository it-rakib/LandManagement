using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictByDistrictId
{
    public class GetAllLandSummaryDistrictByDistrictIdQuery : IRequest<LandSummaryDistrictByDistrictIdVm>
    {
        public Guid DistrictId { get; set; }
    }
}
