using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class OwnerWiseMutationDetail
    {
        public Guid OwnerWiseMutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public Guid OwnerInfoId { get; set; }
        public decimal? OwnerLandAmount { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
        public virtual MutationMaster MutationMaster { get; set; }
        public virtual OwnerInfo OwnerInfo { get; set; }
    }
}
