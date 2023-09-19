using MediatR;
using System;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Commands.CreateUpdateCmnSubRegOffice
{
    public class CreateCmnSubRegOfficeCommand : IRequest<CreateCmnSubRegOfficeCommandResponse>
    {
        public Guid SubRegOfficeId { get; set; }
        public string SubRegOfficeName { get; set; }
        public Guid UpozilaId { get; set; }
        public bool? IsActive { get; set; }
    }
}
