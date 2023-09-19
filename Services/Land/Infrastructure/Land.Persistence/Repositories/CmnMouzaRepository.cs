using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class CmnMouzaRepository : BaseRepository<CmnMouza>, ICmnMouzaRepository
    {
        public CmnMouzaRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<CmnMouzaGridVM>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.CmnMouzas.AsNoTracking().Select(s =>
                                new CmnMouzaGridVM
                                {
                                    MouzaId = s.MouzaId,
                                    MouzaName = s.MouzaName,
                                    UpozilaId = s.UpozilaId,
                                    UpozilaName = s.Upozila.UpozilaName,
                                    DistrictId = s.Upozila.DistrictId,
                                    DistrictName = s.Upozila.District.DistrictName,
                                    DivisionId = s.Upozila.District.DivisionId,
                                    DivisionName = s.Upozila.District.Division.DivisionName
                                }).OrderBy(o => o.MouzaName).AsQueryable();
            var res = KendoGrid<CmnMouzaGridVM>.DataSource(options, data);
            return await Task.FromResult(res);
        }
        public async Task<bool> IsMouzaNameUnique(Guid mouzaId, string mouzaName)
        {
            var existsdata = (await _dbContext.CmnMouzas.AsNoTracking()
                                .Where(a => mouzaId == Guid.Empty ? a.MouzaName == mouzaName : a.MouzaName == mouzaName && a.MouzaId != mouzaId)
                                .OrderBy(o => o.MouzaName).AnyAsync());
            return existsdata != false ? true : false;
        }
        public async Task<List<CmnMouzaByUpozilaIdVM>> GetMouzaByUpozilaIdAsync(Guid upozilaId)
        {
            try
            {
                return await _dbContext.CmnMouzas.AsNoTracking()
                                        .Where(d => d.UpozilaId == upozilaId)
                                        .Select(s => new CmnMouzaByUpozilaIdVM
                                        {
                                            MouzaId = s.MouzaId,
                                            MouzaName = s.MouzaName,
                                            UpozilaId = s.UpozilaId,
                                            UpozilaName = s.Upozila.UpozilaName
                                        }).OrderBy(o => o.MouzaName).ThenBy(tb => tb.UpozilaName).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
