using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaGrid;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ICmnUpozilaRepository : IAsyncRepository<CmnUpozila>
    {
        Task<GridEntity<CmnUpozilaGridVM>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsUpozilaNameUnique(Guid upozilaId, string upozilaName);
        public Task<List<CmnUpozilaByDistrictIdVM>> GetUpozilaByDistrictIdAsync(Guid districtId);
    }
}
