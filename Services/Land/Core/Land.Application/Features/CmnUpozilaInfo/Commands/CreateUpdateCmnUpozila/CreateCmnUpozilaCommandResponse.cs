using Common.Service.Responses;

namespace Land.Application.Features.CmnUpozilaInfo.Commands.CreateUpdateCmnUpozila
{
    public class CreateCmnUpozilaCommandResponse : BaseResponse
    {
        public CreateCmnUpozilaDTO UpozilaDTO { get; set; }
    }
}
