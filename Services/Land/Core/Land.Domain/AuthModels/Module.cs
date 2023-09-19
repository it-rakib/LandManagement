using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class Module
    {
        public int ModuleId { get; set; }
        public int ProjectId { get; set; }
        public string ModuleName { get; set; }
        public string IconName { get; set; }
        public string IconColor { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
