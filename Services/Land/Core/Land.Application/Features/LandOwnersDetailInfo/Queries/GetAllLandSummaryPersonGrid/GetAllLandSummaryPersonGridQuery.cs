using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryPersonGrid
{
    public class GetAllLandSummaryPersonGridQuery : IRequest<GridEntity<GetAllLandSummaryPersonGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
