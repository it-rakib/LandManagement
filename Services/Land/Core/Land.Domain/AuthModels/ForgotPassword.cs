using System;
using System.Collections.Generic;

#nullable disable

namespace Merchandising.Domain.AuthModels
{
    public partial class ForgotPassword
    {
        public string EmpCode { get; set; }
        public string EmpPassword { get; set; }
        public bool? IsExpired { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
