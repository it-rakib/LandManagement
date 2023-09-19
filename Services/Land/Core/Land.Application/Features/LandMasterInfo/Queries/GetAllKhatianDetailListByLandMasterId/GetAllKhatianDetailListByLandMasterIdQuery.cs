using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandDetailListByLandMasterId
{
    public class GetAllKhatianDetailListByLandMasterIdQuery : IRequest<List<KhatianDetailListByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
