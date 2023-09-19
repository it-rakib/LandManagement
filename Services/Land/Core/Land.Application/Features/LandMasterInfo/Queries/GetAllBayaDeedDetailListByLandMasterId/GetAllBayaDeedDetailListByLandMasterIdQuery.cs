using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllBayaDeedDetailListByLandMasterId
{
    public class GetAllBayaDeedDetailListByLandMasterIdQuery : IRequest<List<BayaDeedDetailListByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
