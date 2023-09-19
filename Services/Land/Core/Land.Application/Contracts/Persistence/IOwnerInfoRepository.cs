using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid;
using Land.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface IOwnerInfoRepository : IAsyncRepository<OwnerInfo>
    {
        Task<GridEntity<OwnerInfoGridVm>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsOwnerNameUnique(Guid ownerInfoId, string ownerInfoName);
        Task<int> GetTotalCompany();
        Task<int> GetTotalPerson();
    }
}