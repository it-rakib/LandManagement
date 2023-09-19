using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchandising.Domain.SPModels
{
    [Keyless]
    public class SPGetStyleDropdownVm
    {       
        public string StyleNo { get; set; }
        public Guid StyleId { get; set; }
    }
}
