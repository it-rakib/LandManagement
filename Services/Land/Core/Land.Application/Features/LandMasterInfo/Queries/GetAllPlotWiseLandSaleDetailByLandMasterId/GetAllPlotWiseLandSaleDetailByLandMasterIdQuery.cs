using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandSaleDetailByLandMasterId
{
    public class GetAllPlotWiseLandSaleDetailByLandMasterIdQuery 
        : IRequest<List<PlotWiseLandSaleDetailByLandMasterIdVm>>
    {
        public Guid LandMasterId { get; set; }
    }
}
