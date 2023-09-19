using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandTransferDetailByLandMasterId
{
    public class GetAllPlotWiseLandTransferDetailByLandMasterIdQuery : IRequest<List<PlotWiseLandTransferDetailByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
