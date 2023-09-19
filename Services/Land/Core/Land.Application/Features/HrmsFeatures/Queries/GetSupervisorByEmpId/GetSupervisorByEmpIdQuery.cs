using MediatR;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId
{
    public class GetSupervisorByEmpIdQuery : IRequest<GetSupervisorByEmpIdResponse>
    {
        public long EmpID { get; set; }
    }
}
