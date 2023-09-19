using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class LoginHistory
    {
        public int Lhid { get; set; }
        public string UserId { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogOutTime { get; set; }
        public string Ipaddress { get; set; }
        public string SessionId { get; set; }
    }
}
