using MediatR;
using System;

namespace Land.Application.Features.FileCode.Commands.CreateUpdateFileCode
{
    public class CreateUpdateFileCodeCommand : IRequest<CreateUpdateFileCodeCommandResponse>
    {
        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        public string FileCodeInfoFullName { get; set; }
        public bool? IsActive { get; set; }
    }
}
