using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using Merchandising.Application.Features.HrmsFeatures.Queries.GetIsCSForward;
using Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId;
using Merchandising.Domain.AuthModels;
using Merchandising.Domain.HrmsModels;
using Merchandising.Persistence.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandising.Persistence.Repositories.Hrms
{
    public class Ogranogram_ApplicationsApprovalRepository : HrmsBaseRepository<OgranogramApplicationsApproval>, IOgranogram_ApplicationsApprovalRepository
    {
        private readonly ERPUSERDBContext _erpUserDBContext;

        public Ogranogram_ApplicationsApprovalRepository(ERPUSERDBContext erpUserDBContext, CoreERPContext hrmsDbContext) : base(hrmsDbContext)
        {
            _erpUserDBContext = erpUserDBContext ?? throw new ArgumentNullException(nameof(erpUserDBContext));
        }

        public async Task<bool> ChkIsCSForward(long empId)
        {
            try
            {
                return await _dbContext.OgranogramApplicationsApprovals.Where(f => f.EmpId == empId && f.ProjectId == 2 && f.IsActive == true).AnyAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GetSupervisorByEmpIdResponse> GetSupervisorByEmpId(long empId)
        {
            var response = new GetSupervisorByEmpIdResponse();
            try
            {
                var userIds = await _erpUserDBContext.UserInfos.Where(f => f.IsActive == "Y").AsNoTrackingWithIdentityResolution().ToListAsync();
                List<long> supervisorIDs = await _dbContext.OgranogramApplicationsApprovals
                                                .Where(f => f.EmpId == empId && f.ProjectId == 2 && f.IsActive == true)
                                                .AsNoTrackingWithIdentityResolution()
                                                .Select(s => s.SupervisorEmpId).ToListAsync();
                response.Result = await _dbContext.HumanResourceEmployeeBasics
                                                        .AsNoTrackingWithIdentityResolution()
                                                        .Where(f => supervisorIDs.Contains(f.EmpId))
                                                        .Select(s => new GetSupervisorByEmpIdVm
                                                        {
                                                            Name = s.Name,
                                                            EmpCode = s.EmpCode,
                                                            EmpID = s.EmpId,
                                                            UserId = GetUserId(userIds, s.EmpCode)
                                                        }).OrderBy(o => o.EmpCode).ToListAsync();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return response;
        }

        private static long GetUserId(List<UserInfo> userIds, string empCode)
        {
            try
            {
                return userIds.Where(f => f.EmpId == empCode).Select(s => s.UserId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GetIsCSForwardResponse> IsCSForward(long empId)
        {
            var response = new GetIsCSForwardResponse();
            try
            {
                response.Success = await _dbContext.OgranogramApplicationsApprovals.Where(f => f.EmpId == empId && f.ProjectId == 2 && f.IsActive == true).AnyAsync();
                response.Result = new GetIsCSForwardVm
                {
                    IsCSForward = await _dbContext.OgranogramApplicationsApprovals.Where(f => f.EmpId == empId && f.ProjectId == 2 && f.IsActive == true).AnyAsync()
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return response;
        }
    }
}
