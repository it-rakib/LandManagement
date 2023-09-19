using Common.Service.Responses;
using System.Collections.Generic;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId
{
    public class GetSupervisorByEmpIdResponse : BaseResponse
    {
        public GetSupervisorByEmpIdResponse()
        {
        }
        public List<GetSupervisorByEmpIdVm> Result { get; set; }
    }
}
