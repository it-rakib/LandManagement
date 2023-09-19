using MediatR;

namespace Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetCompanyNameById
{
    public class GetCompanyNameByIdQuery : IRequest<CompanyNameByIdVm>
    {
        public int Id { get; set; }
    }
}
