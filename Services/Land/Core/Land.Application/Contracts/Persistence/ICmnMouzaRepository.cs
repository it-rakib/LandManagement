using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaGrid;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ICmnMouzaRepository : IAsyncRepository<CmnMouza>
    {
        Task<GridEntity<CmnMouzaGridVM>> GetAllPagingAsync(GridOptions options);
        Task<bool> IsMouzaNameUnique(Guid mouzaId, string mouzaName);
        public Task<List<CmnMouzaByUpozilaIdVM>> GetMouzaByUpozilaIdAsync(Guid upozilaId);
    }
}
