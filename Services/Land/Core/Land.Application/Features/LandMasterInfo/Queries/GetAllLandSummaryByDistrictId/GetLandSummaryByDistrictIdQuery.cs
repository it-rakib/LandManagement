using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDistrictId
{
    public class GetLandSummaryByDistrictIdQuery : IRequest<GridEntity<GetLandSummaryByDistrictIdVm>>
    {
        public Guid DistrictId { get; set; }
        public GridOptions options { get; set; }
    }
}
