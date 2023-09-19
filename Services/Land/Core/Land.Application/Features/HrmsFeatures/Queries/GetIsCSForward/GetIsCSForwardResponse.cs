using Common.Service.Responses;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetIsCSForward
{
    public class GetIsCSForwardResponse : BaseResponse
    {
        public GetIsCSForwardResponse()
        {
        }
        public GetIsCSForwardVm Result { get; set; }
    }
}
