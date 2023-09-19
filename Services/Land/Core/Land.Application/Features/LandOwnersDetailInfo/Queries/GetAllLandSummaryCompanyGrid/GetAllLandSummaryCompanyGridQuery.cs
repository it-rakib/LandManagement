using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryCompanyGrid
{
    public class GetAllLandSummaryCompanyGridQuery : IRequest<GridEntity<GetAllLandSummaryCompanyGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
