using Common.Service.Repositories;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ILandOwnerTypeRepository : IAsyncRepository<LandOwnerType>
    {
        Task<List<GetAllLandOwnerTypeListVm>> GetAllLandOwnerTypeAsync();
        Task<List<LandOwnerTypeListByLandMasterIdVm>> GetAllLandOwnerTypeListByLandMasterId(Guid landMasterId);
    }
}
