using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetCompanyNameById;
using Merchandising.Domain.HrmsModels;
using Merchandising.Persistence.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Merchandising.Persistence.Repositories.Hrms
{
    public class CommonCompanyRepository : HrmsBaseRepository<CommonCompany>, ICommonCompanyRepository  
    {
        public CommonCompanyRepository(CoreERPContext context) : base(context)
        {

        }

        public async Task<List<CommonCompanyListVm>> GetCompany()
        {
            try
            {
                var ahsdvfh = _dbContext.CommonUnits.ToList();
                List<int> gmtCompanyId = _dbContext.CommonUnits.Where(f => f.UnitTypeId == 1).Select(s => s.CompanyId).ToList();
                return await _dbContext.CommonCompanies
                                        .Where(f => gmtCompanyId.Contains(f.CompanyId))
                                        .AsNoTrackingWithIdentityResolution()
                                        .Select(s => new CommonCompanyListVm
                                        {
                                            CompanyId = s.CompanyId,
                                            RootCompany = s.RootCompany,
                                            CompanyName = s.CompanyName,
                                            CompanyNameBan = s.CompanyNameBan,
                                            CompanyShortName = s.CompanyShortName,
                                            CompanyAddress = s.CompanyAddress,
                                            IsActive = s.IsActive,
                                            EntryDate = s.EntryDate,
                                            EntryUserId = s.EntryUserId,
                                            TerminalId = s.TerminalId
                                        }).OrderBy(o => o.CompanyName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<CompanyNameByIdVm> GetCompanyNameById(int id)
        {
            return await _dbContext.CommonCompanies.Where(f => f.CompanyId == id).Select(s => new CompanyNameByIdVm { CompanyName = s.CompanyName }).FirstOrDefaultAsync();
        }
    }
}
