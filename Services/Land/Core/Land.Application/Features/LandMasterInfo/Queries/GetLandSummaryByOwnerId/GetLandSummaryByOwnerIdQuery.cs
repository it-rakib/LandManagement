using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId
{
    public class GetLandSummaryByOwnerIdQuery : IRequest<GridEntity<GetLandSummaryByOwnerIdVm>>
    {
        public Guid OwnerInfoId { get; set; }
        public Guid? MouzaId { get; set; }
        public GridOptions options { get; set; }
    }
}
