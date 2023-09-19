using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeGrid;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ICmnSubRegOfficeRepository : IAsyncRepository<CmnSubRegOffice>
    {
        Task<GridEntity<CmnSubRegOfficeGridVM>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsSubRegOfficeNameUnique(Guid subRegOfficeId, string subRegOfficeName);
        public Task<List<CmnSubRegOfficeByUpozilaIdVM>> GetSubRegOfficeByUpozilaIdAsync(Guid upozilaId);
    }
}
