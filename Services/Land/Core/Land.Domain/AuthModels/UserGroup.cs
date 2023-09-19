using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class UserGroup
    {
        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public bool? IsActive { get; set; }
    }
}
