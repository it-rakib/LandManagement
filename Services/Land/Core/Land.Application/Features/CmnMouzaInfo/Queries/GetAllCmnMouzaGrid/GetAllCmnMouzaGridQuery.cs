using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaGrid
{
    public class GetAllCmnMouzaGridQuery : IRequest<GridEntity<CmnMouzaGridVM>>
    {
        public GridOptions options { get; set; }
    }
}
