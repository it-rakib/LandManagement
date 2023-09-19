using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo
{
    public class GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNoQuery : IRequest<decimal>
    {
        public Guid TransferedLandMasterId { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public int TransferedDagNo { get; set; }
    }
}
