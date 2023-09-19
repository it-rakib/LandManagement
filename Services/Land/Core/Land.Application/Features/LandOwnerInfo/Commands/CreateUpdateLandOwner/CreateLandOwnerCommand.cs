using MediatR;
using System;

namespace Land.Application.Features.LandOwnerInfo.Commands.CreateUpdateLandOwner
{
    public class CreateLandOwnerCommand : IRequest<CreateLandOwnerCommandResponse>
    {
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public bool IsCompany { get; set; }
        public bool? IsActive { get; set; }
    }
}
