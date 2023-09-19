using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByMouzaId
{
    public class GetLandSummaryByMouzaIdQuery : IRequest<GridEntity<GetLandSummaryByMouzaIdVm>>
    {
        //private readonly ILandMasterRepository _landMasterRepository;
        public Guid MouzaId { get; set; }
        public GridOptions options { get; set; }

    }
}