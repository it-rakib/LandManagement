using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryOwnerMouzaCommonGrid
{
    public class GetAllLandSummaryOwnerMouzaCommonGridQuery : IRequest<GridEntity<GetAllLandSummaryOwnerMouzaCommonGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
