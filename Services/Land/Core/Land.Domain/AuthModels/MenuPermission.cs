using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class MenuPermission
    {
        public long MenuPermissionId { get; set; }
        public string UserId { get; set; }
        public int MenuId { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
