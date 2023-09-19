using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid
{
    public class GetAllLandDevelopmentTaxGridQuery : IRequest<GridEntity<LandDevelopmentTaxGridVm>>
    {
        public GridOptions options { get; set; }
    }
}
