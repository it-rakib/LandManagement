using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class PlotWiseLandSaleDetail
    {
        public Guid PlotWiseLandSaleDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid SaleLandMasterId { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public int SaleDagNo { get; set; }
        public decimal PlotWiseSaleLandAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
    }
}
