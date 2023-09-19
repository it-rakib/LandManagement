using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class MapType
    {
        public MapType()
        {
            LandMaps = new HashSet<LandMap>();
        }

        public int MapTypeId { get; set; }
        public string MapTypeName { get; set; }

        public virtual ICollection<LandMap> LandMaps { get; set; }
    }
}
