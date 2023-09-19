using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnDistrict
    {
        public CmnDistrict()
        {
            CmnUpozilas = new HashSet<CmnUpozila>();
            LandMaps = new HashSet<LandMap>();
            LandMasters = new HashSet<LandMaster>();
        }

        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }

        public virtual CmnDivision Division { get; set; }
        public virtual ICollection<CmnUpozila> CmnUpozilas { get; set; }
        public virtual ICollection<LandMap> LandMaps { get; set; }
        public virtual ICollection<LandMaster> LandMasters { get; set; }
    }
}
