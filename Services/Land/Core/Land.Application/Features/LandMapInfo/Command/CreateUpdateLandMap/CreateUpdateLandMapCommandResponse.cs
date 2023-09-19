using Common.Service.Responses;

namespace Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap
{
    public class CreateUpdateLandMapCommandResponse : BaseResponse
    {
        public CreateUpdateLandMapDto LandMapDto { get;set;}
    }
}
