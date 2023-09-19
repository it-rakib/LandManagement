using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterIdMouzaId
{
    public class GetAllKhatianTypeListByLandMasterIdMouzaIdQuery : IRequest<List<KhatianTypeListByLandMasterIdMouzaIdVm>>
    {
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
    }
}
