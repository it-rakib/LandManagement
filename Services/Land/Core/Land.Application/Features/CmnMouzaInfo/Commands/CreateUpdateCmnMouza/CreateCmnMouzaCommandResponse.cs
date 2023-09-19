using Common.Service.Responses;

namespace Land.Application.Features.CmnMouzaInfo.Commands.CreateUpdateCmnMouza
{
    public class CreateCmnMouzaCommandResponse : BaseResponse
    {
        public CreateCmnMouzaDTO MouzaDTO { get; set; }
    }
}
