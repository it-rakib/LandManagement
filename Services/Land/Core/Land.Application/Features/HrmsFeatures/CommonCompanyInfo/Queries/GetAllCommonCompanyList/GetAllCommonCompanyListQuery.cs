using MediatR;
using System.Collections.Generic;

namespace Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList
{
    public class GetAllCommonCompanyListQuery : IRequest<List<CommonCompanyListVm>>
    {
    }
}
