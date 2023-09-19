using System;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax
{
    public class CreateOrUpdateLandDevelopmentTaxDto
    {
        public Guid MutationMasterId { get; set; }
        public string HoldingNo { get; set; }
    }
}
