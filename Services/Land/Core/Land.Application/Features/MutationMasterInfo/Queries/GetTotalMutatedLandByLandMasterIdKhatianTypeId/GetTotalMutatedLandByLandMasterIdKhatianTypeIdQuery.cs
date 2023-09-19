using MediatR;
using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetTotalMutatedLandByLandMasterIdKhatianTypeId
{
    public class GetTotalMutatedLandByLandMasterIdKhatianTypeIdQuery : IRequest<decimal>
    {
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
    }
}
