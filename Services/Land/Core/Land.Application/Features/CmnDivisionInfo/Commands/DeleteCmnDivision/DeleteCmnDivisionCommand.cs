using MediatR;
using System;

namespace Land.Application.Features.CmnDivisionInfo.Commands.DeleteCmnDivision
{
    public class DeleteCmnDivisionCommand : IRequest
    {
        public Guid DivisionId { get; set; }
    }
}
