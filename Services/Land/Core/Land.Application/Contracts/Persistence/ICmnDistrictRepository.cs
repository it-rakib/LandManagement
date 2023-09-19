using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictGrid;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ICmnDistrictRepository : IAsyncRepository<CmnDistrict>
    {
        public Task<List<CmnDistrictByDivisionIdVM>> GetDistrictListByDivisionIdAsync(Guid divisionId);
        Task<GridEntity<CmnDistrictGridVM>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsDistrictNameUnique(Guid districtId, string districtName);
    }
}
