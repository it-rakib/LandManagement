using Common.Service.Responses;

namespace Land.Application.Features.CmnDivisionInfo.Commands.CreateUpdateCmnDivision
{
    public class CreateCmnDivisionCommandResponse : BaseResponse
    {
        public CreateCmnDivisionDTO DivisionDTO { get; set; }
    }
}
