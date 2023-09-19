using MediatR;
using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutatedLandAmountByLandMasterKhatianTypeDagNo
{
    public class GetMutatedLandAmountByLandMasterKhatianTypeDagNoQuery : IRequest<decimal>
    {
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string DagNo { get; set; }
    }
}
