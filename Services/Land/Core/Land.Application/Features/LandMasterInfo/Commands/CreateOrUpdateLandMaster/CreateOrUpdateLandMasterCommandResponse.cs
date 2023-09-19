using Common.Service.Responses;

namespace Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster
{
    public class CreateOrUpdateLandMasterCommandResponse : BaseResponse
    {
        public CreateOrUpdateLandMasterCommandResponse()
        {
        }
        public CreateOrUpdateLandMasterDto LandMasterDto { get; set;}
    }
}
