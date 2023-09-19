using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictGrid
{
    public class GetAllLandSummaryDistrictGridQuery : IRequest<GridEntity<GetAllLandSummaryDistrictGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
