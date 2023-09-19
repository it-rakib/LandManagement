using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class KhatianDetail
    {
        public Guid KhatianDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianNo { get; set; }
        public string DagNo { get; set; }
        public string RecordedOwnerName { get; set; }

        public virtual KhatianType KhatianType { get; set; }
        public virtual LandMaster LandMaster { get; set; }
        public virtual CmnMouza Mouza { get; set; }
    }
}
