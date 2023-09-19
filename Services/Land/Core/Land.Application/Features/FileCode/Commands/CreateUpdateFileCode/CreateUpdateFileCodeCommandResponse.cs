using Common.Service.Responses;

namespace Land.Application.Features.FileCode.Commands.CreateUpdateFileCode
{
    public class CreateUpdateFileCodeCommandResponse : BaseResponse
    {
        public CreateUpdateFileCodeDTO FileCodeDTO { get; set; }
    }
}
