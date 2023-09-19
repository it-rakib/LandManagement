using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId
{
    public class GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery : IRequest<decimal>
    { 
        public Guid SaleLandMasterId { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public Guid SaleOwnerInfoId { get; set; }
    }
}
