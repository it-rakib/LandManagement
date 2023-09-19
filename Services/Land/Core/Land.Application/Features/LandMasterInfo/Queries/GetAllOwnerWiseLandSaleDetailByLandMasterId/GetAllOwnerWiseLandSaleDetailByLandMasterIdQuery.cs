using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandSaleDetailByLandMasterId
{
    public class GetAllOwnerWiseLandSaleDetailByLandMasterIdQuery 
        : IRequest<List<OwnerWiseLandSaleDetailByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
