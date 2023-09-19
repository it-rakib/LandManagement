using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaGrid
{
    public class GetAllLandSummaryMouzaGridQuery : IRequest<GridEntity<LandSummaryMouzaGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
