using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandMapKhatianRelation
    {
        public Guid LandMapKhatianRelationId { get; set; }
        public Guid LandMapId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string OtherRemarks { get; set; }

        public virtual KhatianType KhatianType { get; set; }
        public virtual LandMap LandMap { get; set; }
    }
}
