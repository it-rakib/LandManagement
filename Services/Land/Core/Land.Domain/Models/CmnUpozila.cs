using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnUpozila
    {
        public CmnUpozila()
        {
            CmnMouzas = new HashSet<CmnMouza>();
            CmnSubRegOffices = new HashSet<CmnSubRegOffice>();
            LandMaps = new HashSet<LandMap>();
            LandMasters = new HashSet<LandMaster>();
        }

        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid DistrictId { get; set; }

        public virtual CmnDistrict District { get; set; }
        public virtual ICollection<CmnMouza> CmnMouzas { get; set; }
        public virtual ICollection<CmnSubRegOffice> CmnSubRegOffices { get; set; }
        public virtual ICollection<LandMap> LandMaps { get; set; }
        public virtual ICollection<LandMaster> LandMasters { get; set; }
    }
}
