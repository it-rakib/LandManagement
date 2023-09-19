using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class FileLocationDetail
    {
        public Guid FileLocationDetailId { get; set; }
        public Guid FileLocationMasterId { get; set; }
        public Guid LandMasterId { get; set; }

        public virtual FileLocationMaster FileLocationMaster { get; set; }
        public virtual LandMaster LandMaster { get; set; }
    }
}
