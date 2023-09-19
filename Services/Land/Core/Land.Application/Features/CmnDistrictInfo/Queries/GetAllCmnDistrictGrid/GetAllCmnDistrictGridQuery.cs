using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictGrid
{
    public class GetAllCmnDistrictGridQuery : IRequest<GridEntity<CmnDistrictGridVM>>
    {
        public GridOptions options { get; set; }
    }
}
