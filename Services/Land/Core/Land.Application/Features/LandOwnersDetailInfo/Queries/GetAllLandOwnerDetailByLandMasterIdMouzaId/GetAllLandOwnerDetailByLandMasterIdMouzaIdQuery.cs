using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId
{
    public class GetAllLandOwnerDetailByLandMasterIdMouzaIdQuery : IRequest<List<LandOwnerDetailByLandMasterIdMouzaIdVm>>
    {
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
    }
}
