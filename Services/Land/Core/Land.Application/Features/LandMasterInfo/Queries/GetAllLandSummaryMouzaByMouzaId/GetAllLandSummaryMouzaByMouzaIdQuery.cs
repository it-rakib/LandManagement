using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByMouzaId
{
    public class GetAllLandSummaryMouzaByMouzaIdQuery : IRequest<LandSummaryMouzaByMouzaIdVm>
    {
        public Guid MouzaId { get; set; }
    }
}
