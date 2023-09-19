using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class AlmirahNoInfo
    {
        public AlmirahNoInfo()
        {
            RackNoInfos = new HashSet<RackNoInfo>();
        }

        public Guid AlmirahNoInfoId { get; set; }
        public int AlmirahNoInfoName { get; set; }

        public virtual ICollection<RackNoInfo> RackNoInfos { get; set; }
    }
}
