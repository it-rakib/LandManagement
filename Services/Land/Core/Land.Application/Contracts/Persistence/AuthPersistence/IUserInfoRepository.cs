using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Merchandising.Application.AuthFeatures.Users.Queries.GetAllUserList;
using Merchandising.Domain.AuthModels;
using System.Threading.Tasks;

namespace Merchandising.Application.Contracts.Persistence.AuthPersistence
{
    public interface IUserInfoRepository : IAsyncAuthRepository<UserInfo>
    {
        Task<GridEntity<UserListVm>> GetAllPagingAsync(GridOptions options);
    }
}
