using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnSubRegOffice
    {
        public CmnSubRegOffice()
        {
            LandMasters = new HashSet<LandMaster>();
        }

        public Guid SubRegOfficeId { get; set; }
        public string SubRegOfficeName { get; set; }
        public Guid UpozilaId { get; set; }
        public bool? IsActive { get; set; }

        public virtual CmnUpozila Upozila { get; set; }
        public virtual ICollection<LandMaster> LandMasters { get; set; }
    }
}
