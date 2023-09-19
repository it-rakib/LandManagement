using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnMouza
    {
        public CmnMouza()
        {
            KhatianDetails = new HashSet<KhatianDetail>();
            LandMaps = new HashSet<LandMap>();
            LandOwnersDetails = new HashSet<LandOwnersDetail>();
        }

        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid UpozilaId { get; set; }

        public virtual CmnUpozila Upozila { get; set; }
        public virtual ICollection<KhatianDetail> KhatianDetails { get; set; }
        public virtual ICollection<LandMap> LandMaps { get; set; }
        public virtual ICollection<LandOwnersDetail> LandOwnersDetails { get; set; }
    }
}
