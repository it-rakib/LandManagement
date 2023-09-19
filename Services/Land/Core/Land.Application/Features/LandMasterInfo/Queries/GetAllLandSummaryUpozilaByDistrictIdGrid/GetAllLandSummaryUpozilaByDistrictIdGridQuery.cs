using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaByDistrictIdGrid
{
    public class GetAllLandSummaryUpozilaByDistrictIdGridQuery : IRequest<GridEntity<LandSummaryUpozilaByDistrictIdGridVm>>
    {
        public GridOptions options { get; set; }
        public Guid DistrictId { get; set; }
    }
}
