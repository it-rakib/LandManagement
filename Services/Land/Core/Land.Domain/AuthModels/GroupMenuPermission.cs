using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class GroupMenuPermission
    {
        public int MenuPermissionId { get; set; }
        public int GroupId { get; set; }
        public int MenuId { get; set; }
        public int? ProjectId { get; set; }
    }
}
