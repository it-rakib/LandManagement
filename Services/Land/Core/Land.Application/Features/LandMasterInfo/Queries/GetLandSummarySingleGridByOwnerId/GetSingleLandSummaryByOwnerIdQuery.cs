using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandSummarySingleGridByOwnerId
{
    public class GetSingleLandSummaryByOwnerIdQuery : IRequest<GridEntity<GetLandSummaryByOwnerIdVm>>
    {
        public GridOptions options { get; set; }
        public Guid OwnerInfoId { get; set; }
    }
}
