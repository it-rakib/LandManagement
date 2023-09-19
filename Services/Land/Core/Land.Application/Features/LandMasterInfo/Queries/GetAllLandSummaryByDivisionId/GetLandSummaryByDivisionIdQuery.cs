using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId
{
    public class GetLandSummaryByDivisionIdQuery : IRequest<GridEntity<GetAllLandSummaryByDivisionIdVm>>
    {
        public Guid DivisionId { get; set; }
        public GridOptions options { get; set; }
    }
}
