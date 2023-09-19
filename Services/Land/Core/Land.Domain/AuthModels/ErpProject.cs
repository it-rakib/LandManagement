using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class ErpProject
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsActive { get; set; }
    }
}
