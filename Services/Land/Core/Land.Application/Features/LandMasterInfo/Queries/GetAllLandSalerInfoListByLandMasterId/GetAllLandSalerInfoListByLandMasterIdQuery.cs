using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSalerInfoListByLandMasterId
{
    public class GetAllLandSalerInfoListByLandMasterIdQuery : IRequest<List<LandSalerInfoListByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
