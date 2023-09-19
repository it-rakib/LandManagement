using MediatR;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetIsCSForward
{
    public class GetIsCSForwardQuery : IRequest<GetIsCSForwardResponse>
    {
        public long EmpId { get; set; }
    }
}
