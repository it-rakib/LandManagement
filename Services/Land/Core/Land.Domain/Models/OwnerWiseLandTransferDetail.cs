using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class OwnerWiseLandTransferDetail
    {
        public Guid OwnerWiseLandTransferDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid TransferedLandMasterId { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public Guid TransferedOwnerInfoId { get; set; }
        public decimal OwnerWiseTransferedLandAmount { get; set; }

        public virtual LandMaster LandMaster { get; set; }
    }
}
