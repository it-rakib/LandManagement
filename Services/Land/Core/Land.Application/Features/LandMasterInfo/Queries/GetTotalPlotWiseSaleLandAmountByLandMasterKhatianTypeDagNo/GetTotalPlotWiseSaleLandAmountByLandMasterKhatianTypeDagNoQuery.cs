using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo
{
    public class GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNoQuery : IRequest<decimal>
    {
        public Guid SaleLandMasterId { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public int SaleDagNo { get; set; }
    }
}
