using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandOwnerType
    {
        public LandOwnerType()
        {
            LandMasterOwnerRelations = new HashSet<LandMasterOwnerRelation>();
        }

        public Guid LandOwnerTypeId { get; set; }
        public string LandOwnerTypeName { get; set; }
        public int? OrderBy { get; set; }

        public virtual ICollection<LandMasterOwnerRelation> LandMasterOwnerRelations { get; set; }
    }
}
