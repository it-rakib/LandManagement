using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class UserLevelMap
    {
        public long UserId { get; set; }
        public int ProjectId { get; set; }
        public int? LavelId { get; set; }
    }
}
