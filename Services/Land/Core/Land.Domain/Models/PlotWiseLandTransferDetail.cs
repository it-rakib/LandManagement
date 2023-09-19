using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class PlotWiseLandTransferDetail
    {
        public Guid PlotWiseLandTransferDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid TransferedLandMasterId { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public int TransferedDagNo { get; set; }
        public decimal PlotWiseTransferedLandAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
    }
}
