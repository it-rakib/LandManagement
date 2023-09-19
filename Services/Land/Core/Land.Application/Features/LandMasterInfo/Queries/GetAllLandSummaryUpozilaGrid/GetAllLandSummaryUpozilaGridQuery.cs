using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaGrid
{
    public class GetAllLandSummaryUpozilaGridQuery : IRequest<GridEntity<LandSummaryUpozilaGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
