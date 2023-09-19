using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationGrid;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface IFileLocationRepository : IAsyncRepository<FileLocationMaster>
    {
        Task<bool> IsFileNoUnique(Guid fileLocationMasterId, Guid fileNoInfoId);
        Task<FileLocationMaster> GetFileLocationMasterById(Guid fileLocationMasterId);
        Task<FileLocationMaster> UpdateFileLocationMaster(FileLocationMaster fileLocationMaster);

        Task<GridEntity<FileLocationGridVm>> GetAllPagingAsync(GridOptions options);
        Task<List<FileLocationDetailListByFileLocationMasterIdVm>> GetAllFileLocationDetailListByFileLocationMasterId(Guid fileLocationMasterId);
        Task<List<FileLocationDetailListVm>> GetAllFileLocationDetailList();
    }
}
