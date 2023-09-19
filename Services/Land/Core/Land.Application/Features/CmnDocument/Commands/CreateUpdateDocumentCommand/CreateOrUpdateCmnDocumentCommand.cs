using MediatR;
using System;

namespace Land.Application.Features.CmnDocument.Commands.CreateUpdateDocumentCommand
{
    public class CreateOrUpdateCmnDocumentCommand : IRequest<CreateOrUpdateCmnDocumentCommandResponse>
    {
        //public Guid DocumentId { get; set; }
        public string FileName { get; set; }
        public string ModuleName { get; set; }
        public Guid ModuleMasterId { get; set; }
        public int FileSize { get; set; }
        public string FileExtension { get; set; }
        public string FileUniqueName { get; set; }
        public string ActionType { get; set; }
    }
}
