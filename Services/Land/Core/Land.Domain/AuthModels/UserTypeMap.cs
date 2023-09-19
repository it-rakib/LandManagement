using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class UserTypeMap
    {
        public long UserId { get; set; }
        public int ProjectId { get; set; }
        public int? UserTypeId { get; set; }
    }
}
