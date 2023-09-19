using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class OwnerInfo
    {
        public OwnerInfo()
        {
            LandOwnersDetails = new HashSet<LandOwnersDetail>();
            OwnerWiseMutationDetails = new HashSet<OwnerWiseMutationDetail>();
        }

        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public bool IsCompany { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<LandOwnersDetail> LandOwnersDetails { get; set; }
        public virtual ICollection<OwnerWiseMutationDetail> OwnerWiseMutationDetails { get; set; }
    }
}
