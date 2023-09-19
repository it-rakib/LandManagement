using Common.Service.Responses;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Commands.CreateUpdateCmnSubRegOffice
{
    public class CreateCmnSubRegOfficeCommandResponse : BaseResponse
    {
        public CreateCmnSubRegOfficeDto SubRegOfficeDto { get; set; }
    }
}
