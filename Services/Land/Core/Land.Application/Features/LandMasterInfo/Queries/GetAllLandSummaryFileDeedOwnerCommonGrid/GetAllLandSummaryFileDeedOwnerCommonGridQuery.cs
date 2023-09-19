using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryFileDeedOwnerCommonGrid
{
    public class GetAllLandSummaryFileDeedOwnerCommonGridQuery : IRequest<GridEntity<GetAllLandSummaryFileDeedOwnerCommonGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
