using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId
{
    public class GetAllPlotWiseMutationDetailListByMutationMasterIdQuery : IRequest<List<PlotWiseMutationDetailListByMutationMasterIdVm>>
    {
        public Guid MutationMasterId { get; set; }
    }
}
