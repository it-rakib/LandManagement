using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandOwnersDetail
    {
        public Guid LandOwnersDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string SaleOwnerName { get; set; }
        public Guid MouzaId { get; set; }
        public decimal? LandAmount { get; set; }
        public decimal? OwnerRegAmount { get; set; }
        public decimal? OwnerPurchaseAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
        public virtual CmnMouza Mouza { get; set; }
        public virtual OwnerInfo OwnerInfo { get; set; }
    }
}
