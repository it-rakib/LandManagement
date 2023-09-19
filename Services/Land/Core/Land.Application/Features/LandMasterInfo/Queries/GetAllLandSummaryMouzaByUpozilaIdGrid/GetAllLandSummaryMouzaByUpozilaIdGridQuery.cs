using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByUpozilaIdGrid
{
    public class GetAllLandSummaryMouzaByUpozilaIdGridQuery : IRequest<GridEntity<LandSummaryMouzaByUpozilaIdGridVm>>
    {
        public GridOptions options { get; set; }
        public Guid UpozilaId { get; set; }
    }
    
}
