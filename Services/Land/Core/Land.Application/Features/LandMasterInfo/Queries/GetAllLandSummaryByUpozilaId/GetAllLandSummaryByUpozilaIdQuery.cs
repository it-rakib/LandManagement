using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByUpozilaId
{
    public class GetAllLandSummaryByUpozilaIdQuery : IRequest<GridEntity<GetAllLandSummaryByUpozilaIdVm>>
    {
        public Guid UpozilaId { get; set; }
        public GridOptions options { get; set; }
    }
}
