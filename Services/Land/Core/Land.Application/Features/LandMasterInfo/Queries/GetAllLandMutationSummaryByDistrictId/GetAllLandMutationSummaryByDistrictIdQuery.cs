using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDistrictId
{
    public class GetAllLandMutationSummaryByDistrictIdQuery : IRequest<GridEntity<GetAllLandMutationSummaryByDistrictIdVm>>
    {
        public Guid districtId { get; set; }
        public GridOptions options { get; set; }

        public GetAllLandMutationSummaryByDistrictIdQuery(GridOptions options, Guid districtId)
        {
            this.options = options;
            this.districtId = districtId;
        }

        
    }
}
