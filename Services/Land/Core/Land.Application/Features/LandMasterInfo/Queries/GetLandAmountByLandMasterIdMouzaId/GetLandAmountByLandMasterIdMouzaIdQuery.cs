using System;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandAmountByLandMasterIdMouzaId
{
    public class GetLandAmountByLandMasterIdMouzaIdQuery : IRequest<decimal>
    {
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
    }
}
