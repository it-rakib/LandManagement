using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class SheetNoInfo
    {
        public SheetNoInfo()
        {
            LandMaps = new HashSet<LandMap>();
        }

        public Guid SheetNoInfoId { get; set; }
        public int SheetNo { get; set; }

        public virtual ICollection<LandMap> LandMaps { get; set; }
    }
}
