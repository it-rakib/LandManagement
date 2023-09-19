using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchandising.Domain.SPModels
{
    public partial class SPModelsContext : DbContext
    {
        public SPModelsContext(DbContextOptions<SPModelsContext> options)
            : base(options)
        {

        }
    }
}
