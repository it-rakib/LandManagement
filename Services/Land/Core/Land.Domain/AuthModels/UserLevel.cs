using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class UserLevel
    {
        public int UserLevelId { get; set; }
        public string UserLevelName { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }
    }
}
