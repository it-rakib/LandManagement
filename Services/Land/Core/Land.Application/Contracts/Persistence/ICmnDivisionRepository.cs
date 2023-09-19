using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionGrid;
using Land.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ICmnDivisionRepository : IAsyncRepository<CmnDivision>
    {
        Task<GridEntity<GetAllCmnDivisionGridVM>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsDivisionNameUnique(Guid divisionId, string divisionName);
    }
}
