using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId
{
    public class GetAllLandOwnerTypeListByLandMasterIdQuery : IRequest<List<LandOwnerTypeListByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
