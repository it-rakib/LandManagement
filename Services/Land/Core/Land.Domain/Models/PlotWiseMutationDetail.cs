using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class PlotWiseMutationDetail
    {
        public Guid PlotWiseMutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianNo { get; set; }
        public string DagNo { get; set; }
        public decimal PlotWiseMutationLandAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
        public virtual MutationMaster MutationMaster { get; set; }
    }
}
