using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterId
{
    public class GetAllKhatianTypeListByLandMasterIdQuery : IRequest<List<KhatianTypeListByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
