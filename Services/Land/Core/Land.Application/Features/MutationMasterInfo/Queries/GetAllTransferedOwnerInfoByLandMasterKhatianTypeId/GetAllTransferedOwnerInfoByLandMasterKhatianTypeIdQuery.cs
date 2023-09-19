using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId
{
    public class GetAllTransferedOwnerInfoByLandMasterKhatianTypeIdQuery : IRequest<List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>>
    {
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
    }
}
