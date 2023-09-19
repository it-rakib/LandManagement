using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Commands.DeleteCmnDistrict
{
    public class DeleteCmnDistrictCommand : IRequest
    {
        public Guid DistrictId { get; set; }
    }
}
