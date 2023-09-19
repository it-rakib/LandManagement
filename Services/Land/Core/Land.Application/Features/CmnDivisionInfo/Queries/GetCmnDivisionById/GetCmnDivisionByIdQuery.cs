using MediatR;
using System;

namespace Land.Application.Features.CmnDivisionInfo.Queries.GetCmnDivisionById
{
    public class GetCmnDivisionByIdQuery : IRequest<CmnDivisionByIdVM>
    {
        public Guid DivisionId { get; set; }
    }
}
