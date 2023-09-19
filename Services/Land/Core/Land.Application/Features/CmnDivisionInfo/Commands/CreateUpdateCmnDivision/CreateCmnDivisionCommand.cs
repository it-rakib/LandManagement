using MediatR;
using System;

namespace Land.Application.Features.CmnDivisionInfo.Commands.CreateUpdateCmnDivision
{
    public class CreateCmnDivisionCommand : IRequest<CreateCmnDivisionCommandResponse>
    {
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}
