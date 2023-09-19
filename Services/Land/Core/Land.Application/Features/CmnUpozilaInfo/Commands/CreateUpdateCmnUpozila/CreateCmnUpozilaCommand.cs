using MediatR;
using System;

namespace Land.Application.Features.CmnUpozilaInfo.Commands.CreateUpdateCmnUpozila
{
    public class CreateCmnUpozilaCommand : IRequest<CreateCmnUpozilaCommandResponse>
    {
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid DistrictId { get; set; }
    }
}
