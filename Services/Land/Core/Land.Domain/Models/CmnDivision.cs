using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnDivision
    {
        public CmnDivision()
        {
            CmnDistricts = new HashSet<CmnDistrict>();
            LandMaps = new HashSet<LandMap>();
            LandMasters = new HashSet<LandMaster>();
        }

        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }

        public virtual ICollection<CmnDistrict> CmnDistricts { get; set; }
        public virtual ICollection<LandMap> LandMaps { get; set; }
        public virtual ICollection<LandMaster> LandMasters { get; set; }
    }
}
