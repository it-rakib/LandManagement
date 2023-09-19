using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandOwnerListByLandMasterId
{
    public class GetAllLandOwnerListByLandMasterIdQuery : IRequest<List<LandOwnerListByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
