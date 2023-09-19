using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class MutationDetail
    {
        public Guid MutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public decimal? TotalLandAmount { get; set; }
        public decimal MutationLandAmount { get; set; }
        public decimal? RemainLandAmount { get; set; }
        public string Remarks { get; set; }

        public virtual LandMaster LandMaster { get; set; }
        public virtual MutationMaster MutationMaster { get; set; }
    }
}
