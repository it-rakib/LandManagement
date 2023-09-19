using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class UserGroupPermission
    {
        public int GroupPermissionId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
