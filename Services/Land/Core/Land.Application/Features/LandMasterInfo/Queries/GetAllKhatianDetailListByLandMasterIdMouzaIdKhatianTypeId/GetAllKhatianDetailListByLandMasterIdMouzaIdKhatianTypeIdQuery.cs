using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId
{
    public class GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdQuery : IRequest<List<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>>
    {
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
        public Guid KhatianTypeId { get; set; }
    }
}
