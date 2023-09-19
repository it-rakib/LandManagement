using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandTransferDetailByLandMasterId
{
    public class GetAllOwnerWiseLandTransferDetailByLandMasterIdQuery : IRequest<List<OwnerWiseLandTransferDetailByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
