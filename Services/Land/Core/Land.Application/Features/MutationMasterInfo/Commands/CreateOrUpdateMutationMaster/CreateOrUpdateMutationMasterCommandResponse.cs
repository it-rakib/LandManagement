using Common.Service.Responses;

namespace Land.Application.Features.MutationMasterInfo.Commands.CreateOrUpdateMutationMaster
{
    public class CreateOrUpdateMutationMasterCommandResponse : BaseResponse
    {
        public CreateOrUpdateMutationMasterCommandResponse()
        {
            
        }
        public CreateOrUpdateMutationMasterDto MutationMasterDto { get; set; }
    }
}
