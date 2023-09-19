using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMasterGrid
{
    public class GetAllLandMasterGridQuery : IRequest<GridEntity<GetAllLandMasterGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
