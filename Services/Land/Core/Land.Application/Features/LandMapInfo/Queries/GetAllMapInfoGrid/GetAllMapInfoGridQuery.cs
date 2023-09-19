using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMapInfo.Queries.GetAllMapInfoGrid
{
    public class GetAllMapInfoGridQuery : IRequest<GridEntity<GetAllMapInfoGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
