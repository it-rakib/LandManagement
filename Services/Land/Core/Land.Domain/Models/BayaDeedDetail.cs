using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class BayaDeedDetail
    {
        public Guid BayaDeedDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public string BayaDeedNo { get; set; }
        public DateTime? BayaDeedDate { get; set; }

        public virtual LandMaster LandMaster { get; set; }
    }
}
