using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int ReportCode { get; set; }
        public int MenuId { get; set; }
        public string ReportName { get; set; }
        public int? IsActive { get; set; }
        public int? SortOrder { get; set; }
    }
}
