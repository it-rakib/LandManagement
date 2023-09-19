using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerMouzaListByOwnerInfoId
{
    public class GetAllLandSummaryOwnerMouzaListByOwnerInfoIdQuery : IRequest<List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>>
    {
        public Guid OwnerInfoId { get; set; }
    }
}
