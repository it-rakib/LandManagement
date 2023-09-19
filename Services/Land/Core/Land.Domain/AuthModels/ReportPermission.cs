using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class ReportPermission
    {
        public long ReportPermissionId { get; set; }
        public string UserId { get; set; }
        public int ReportId { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
