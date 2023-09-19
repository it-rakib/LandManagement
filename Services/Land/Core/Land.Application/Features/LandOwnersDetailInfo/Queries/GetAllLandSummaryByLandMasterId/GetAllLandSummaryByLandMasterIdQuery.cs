using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId
{
    public class GetAllLandSummaryByLandMasterIdQuery : IRequest<List<LandSummaryByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
