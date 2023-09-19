using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandSaleDetailByLandMasterId
{
    public class OwnerWiseLandSaleDetailByLandMasterIdVm
    {
        public Guid OwnerWiseLandSaleDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid SaleLandMasterId { get; set; }
        public string SaleDeedNo { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public string SaleKhatianTypeName { get; set; }
        public Guid SaleOwnerInfoId { get; set; }
        public string SaleOwnerInfoName { get; set; }
        public decimal OwnerWiseSaleLandAmount { get; set; }
    }
}
