using Common.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDocument.Commands.CreateUpdateDocumentCommand
{
    public class CreateOrUpdateCmnDocumentCommandResponse : BaseResponse
    {
        public CreateOrUpdateCmnDocumentCommandResponse()
        {
        }
        public CreateOrUpdateCmnDocumentDto cmnDto { get; set; }
    }
}
