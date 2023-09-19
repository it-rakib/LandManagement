using Common.Service.Responses;

namespace Land.Application.Features.LandOwnerInfo.Commands.CreateUpdateLandOwner
{
    public class CreateLandOwnerCommandResponse : BaseResponse
    {
        public CreateLandOwnerDto LandOwnerDto { get; set; }
    }
}
