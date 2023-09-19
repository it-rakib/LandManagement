using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.FileCode.Queries.GetAllFileCodeGrid
{
    public class GetAllFileCodeGridQuery : IRequest<GridEntity<GetAllFileCodeGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
