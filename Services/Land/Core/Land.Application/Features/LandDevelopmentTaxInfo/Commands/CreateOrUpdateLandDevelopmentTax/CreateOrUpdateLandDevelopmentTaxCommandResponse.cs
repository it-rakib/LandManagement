using Common.Service.Responses;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax
{
    public class CreateOrUpdateLandDevelopmentTaxCommandResponse : BaseResponse
    {
        public CreateOrUpdateLandDevelopmentTaxDto LandDevelopmentTaxDto { get; set; }
    }
}
