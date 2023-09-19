using MediatR;
using System;

namespace Land.Application.Features.CmnMouzaInfo.Commands.CreateUpdateCmnMouza
{
    public class CreateCmnMouzaCommand : IRequest<CreateCmnMouzaCommandResponse>
    {
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid UpozilaId { get; set; }
    }
}
