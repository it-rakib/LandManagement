using Common.Service.Responses;

namespace Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation
{
    public class CreateFileLocationCommandResponse : BaseResponse
    {
        public CreateFileLocationDto FileLocationDto { get; set; }
    }
}
