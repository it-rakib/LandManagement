using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId
{
    public class GetAllLandSummaryOwnerUpozilaListByOwnerInfoIdQuery : IRequest<List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>>
    {
        public Guid OwnerInfoId { get; set; }
    }
}
