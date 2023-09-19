using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class KhatianType
    {
        public KhatianType()
        {
            KhatianDetails = new HashSet<KhatianDetail>();
        }

        public Guid KhatianTypeId { get; set; }
        public string KhatianTypeName { get; set; }
        public int? OrderBy { get; set; }

        public virtual ICollection<KhatianDetail> KhatianDetails { get; set; }
    }
}
