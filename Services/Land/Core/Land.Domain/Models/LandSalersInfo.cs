using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandSalersInfo
    {
        public Guid SalersInfoId { get; set; }
        public Guid LandMasterId { get; set; }
        public string SalerName { get; set; }
        public string SalerFatherName { get; set; }
        public string SalerAddress { get; set; }

        public virtual LandMaster LandMaster { get; set; }
    }
}
