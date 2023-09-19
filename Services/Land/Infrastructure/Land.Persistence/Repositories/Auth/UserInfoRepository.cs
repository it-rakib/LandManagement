using Common.Service.CommonEntities.KendoGrid;
using Merchandising.Application.AuthFeatures.Users.Queries.GetAllUserList;
using Merchandising.Application.Contracts.Persistence.AuthPersistence;
using Merchandising.Domain.AuthModels;
using Merchandising.Persistence.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandising.Persistence.Repositories.Auth
{
    public class UserInfoRepository : AuthBaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(ERPUSERDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<GridEntity<UserListVm>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.UserInfos.AsNoTracking().Select(s =>
                                new UserListVm
                                {
                                    UserId = s.UserId,
                                    EmpId = s.EmpId,
                                    EmpNo=s.EmpNo,
                                    UserName=s.UserName,
                                    UsrPass=s.UsrPass,
                                    UserType=s.UserType,
                                    CompanyId=s.CompanyId,
                                    UnitId=s.UnitId,
                                    DepartmentId=s.DepartmentId,
                                    DesignationId=s.DesignationId,
                                    UsrDesig=s.UsrDesig,
                                    PhoneNo=s.PhoneNo,
                                    Email=s.Email,
                                    LastLoginDate=s.LastLoginDate,
                                    InvalidLoginTry=s.InvalidLoginTry,
                                    IsLocked=s.IsLocked,
                                    UserLevelId=s.UserLevelId,
                                    IsITAdmin=s.IsItadmin,
                                    IsActive=s.IsActive,
                                    RowDate=s.RowDate,
                                    HRMIS_User=s.HrmisUser,
                                    Merchandising_User=s.MerchandisingUser,
                                    IsSetPass=s.IsSetPass

                                }).OrderBy(o => o.UserName).AsQueryable();
            var res = KendoGrid<UserListVm>.DataSource(options, data);
            return await Task.FromResult(res);

        }

    }
}

