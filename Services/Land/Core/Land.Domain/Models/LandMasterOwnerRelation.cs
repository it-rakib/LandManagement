using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandMasterOwnerRelation
    {
        public Guid LandMasterOwnerRelationId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid LandOwnerTypeId { get; set; }
        public string OtherRemarks { get; set; }

        public virtual LandMaster LandMaster { get; set; }
        public virtual LandOwnerType LandOwnerType { get; set; }
    }
}
