using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDivisionId
{
    public class GetAllLandMutationSummaryByDivisionIdQuery : IRequest<GridEntity<GetAllLandMutationSummaryByDivisionIdVm>>
    {
        public GridOptions options { get; set; }
        public Guid DivisionId { get; set; }
        public GetAllLandMutationSummaryByDivisionIdQuery(GridOptions options, Guid divisionId)
        {
            this.options = options;
            DivisionId = divisionId;
        }
    }
}
