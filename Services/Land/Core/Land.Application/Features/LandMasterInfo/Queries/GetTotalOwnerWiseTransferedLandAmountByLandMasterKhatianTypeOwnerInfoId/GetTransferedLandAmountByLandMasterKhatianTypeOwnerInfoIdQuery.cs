using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId
{
    public class GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery 
        : IRequest<decimal>
    {
        public Guid TransferedLandMasterId { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public Guid TransferedOwnerInfoId { get; set; }
    }
}
