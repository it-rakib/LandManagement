using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Commands.DeleteLandOwner
{
    public class DeleteLandOwnerCommand : IRequest
    {
        public Guid OwnerInfoId { get; set; }
    }
}
