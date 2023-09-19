using Land.Application.Features.CmnDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap
{
    public class CreateUpdateLandMapDto
    {
        public Guid LandMapId { get; set; }
        public Guid SheetNoInfoId { get; set; }
    }
}
