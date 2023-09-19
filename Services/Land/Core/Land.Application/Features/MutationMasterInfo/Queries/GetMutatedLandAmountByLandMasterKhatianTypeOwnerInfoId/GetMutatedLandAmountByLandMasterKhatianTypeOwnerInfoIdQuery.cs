using MediatR;
using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId
{
    public class GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery : IRequest<decimal>
    {
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public Guid OwnerInfoId { get; set; }
    }
}
