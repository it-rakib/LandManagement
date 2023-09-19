using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.LandMapInfo.Queries.GetAllMapInfoGrid;
using Land.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ILandMapRepository : IAsyncRepository<LandMap>
    {
        Task<GridEntity<GetAllMapInfoGridVm>> GetAllMapGrid(GridOptions options);
        Task<LandMap> GetLandMapById(Guid landMapId);
        //Task<bool> IsMapExist(Guid landMapId);
        //Task<LandMap> UpdateLandMap(LandMap landMap);

    }
}
