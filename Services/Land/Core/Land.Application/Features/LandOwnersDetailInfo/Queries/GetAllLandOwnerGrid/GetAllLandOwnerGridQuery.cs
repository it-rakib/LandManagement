using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerGrid
{
    public class GetAllLandOwnerGridQuery : IRequest<GridEntity<LandOwnerGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
