using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeGrid
{
    public class GetAllCmnSubRegOfficeGridQuery : IRequest<GridEntity<CmnSubRegOfficeGridVM>>
    {
        public GridOptions options { get; set; }
    }
}
