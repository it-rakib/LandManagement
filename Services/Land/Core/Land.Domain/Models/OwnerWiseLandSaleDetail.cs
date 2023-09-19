using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class OwnerWiseLandSaleDetail
    {
        public Guid OwnerWiseLandSaleDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid SaleLandMasterId { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public Guid SaleOwnerInfoId { get; set; }
        public decimal OwnerWiseSaleLandAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
    }
}
