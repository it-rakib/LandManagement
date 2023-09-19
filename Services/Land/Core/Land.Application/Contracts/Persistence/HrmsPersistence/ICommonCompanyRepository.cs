using Common.Service.Repositories;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetCompanyNameById;
using Merchandising.Domain.HrmsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchandising.Application.Contracts.Persistence.HrmsPersistence
{
    public interface ICommonCompanyRepository : IAsyncRepository<CommonCompany>
    {
        Task<CompanyNameByIdVm> GetCompanyNameById(int id);
        Task<List<CommonCompanyListVm>> GetCompany();
    }
}
