using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid;
using MediatR;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoGrid
{
    public class GetAllOwnerInfoGridQuery : IRequest<GridEntity<OwnerInfoGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
