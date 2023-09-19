using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionGrid
{
    public class GetAllCmnDivisionGridQuery : IRequest<GridEntity<GetAllCmnDivisionGridVM>>
    {
        public GridOptions options { get; set; }
    }
}
