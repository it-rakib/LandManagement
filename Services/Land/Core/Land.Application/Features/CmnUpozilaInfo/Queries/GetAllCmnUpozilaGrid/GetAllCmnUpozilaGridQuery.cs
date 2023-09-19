using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaGrid
{
    public class GetAllCmnUpozilaGridQuery : IRequest<GridEntity<CmnUpozilaGridVM>>
    {
        public GridOptions options { get; set; }
    }
}
