using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class RackNoInfo
    {
        public RackNoInfo()
        {
            FileLocationMasters = new HashSet<FileLocationMaster>();
        }

        public Guid RackNoInfoId { get; set; }
        public Guid AlmirahNoInfoId { get; set; }
        public int RackNoInfoName { get; set; }

        public virtual AlmirahNoInfo AlmirahNoInfo { get; set; }
        public virtual ICollection<FileLocationMaster> FileLocationMasters { get; set; }
    }
}
