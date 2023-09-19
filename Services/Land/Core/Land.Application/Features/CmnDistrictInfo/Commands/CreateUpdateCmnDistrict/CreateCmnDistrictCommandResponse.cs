using Common.Service.Responses;

namespace Land.Application.Features.CmnDistrictInfo.Commands.CreateUpdateCmnDistrict
{
    public class CreateCmnDistrictCommandResponse : BaseResponse
    {
        public CreateCmnDistrictDTO DistrictDTO { get; set; }
    }
}
