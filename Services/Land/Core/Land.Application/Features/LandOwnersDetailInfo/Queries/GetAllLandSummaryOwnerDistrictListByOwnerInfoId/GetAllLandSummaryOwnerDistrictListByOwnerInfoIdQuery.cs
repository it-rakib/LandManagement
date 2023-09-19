using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId
{
    public class GetAllLandSummaryOwnerDistrictListByOwnerInfoIdQuery : IRequest<List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>>
    {
        public Guid OwnerInfoId { get; set; }
    }
}
