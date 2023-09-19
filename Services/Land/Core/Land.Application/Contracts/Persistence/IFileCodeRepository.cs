using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.FileCode.Queries.GetAllFileCodeGrid;
using Land.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface IFileCodeRepository : IAsyncRepository<FileCodeInfo>
    {
        Task<GridEntity<GetAllFileCodeGridVm>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsFileCodeNameUnique(Guid fileCodeId, string fileCodeName);
    }
}
