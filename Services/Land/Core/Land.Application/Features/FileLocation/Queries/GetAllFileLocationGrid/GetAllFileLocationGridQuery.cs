using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationGrid
{
    public class GetAllFileLocationGridQuery : IRequest<GridEntity<FileLocationGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
