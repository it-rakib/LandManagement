using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class CmnSubRegOfficeRepository : BaseRepository<CmnSubRegOffice>, ICmnSubRegOfficeRepository
    {
        public CmnSubRegOfficeRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<CmnSubRegOfficeGridVM>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.CmnSubRegOffices.AsNoTracking()
                                 .Where(f=>f.IsActive == true)
                                 .Include(i => i.Upozila)
                                 .ThenInclude(j => j.District)
                                 .ThenInclude(k => k.Division)
                                 .Select(s => new CmnSubRegOfficeGridVM
                                 {
                                     SubRegOfficeId = s.SubRegOfficeId,
                                     SubRegOfficeName = s.SubRegOfficeName,
                                     UpozilaId = s.UpozilaId,
                                     UpozilaName = s.Upozila.UpozilaName,
                                     IsActive = s.IsActive,
                                     DistrictId = s.Upozila.District.DistrictId,
                                     DistrictName = s.Upozila.District.DistrictName,
                                     DivisionId = s.Upozila.District.Division.DivisionId,
                                     DivisionName = s.Upozila.District.Division.DivisionName
                                 }).OrderBy(o => o.SubRegOfficeName).AsQueryable();
            var res = KendoGrid<CmnSubRegOfficeGridVM>.DataSource(options, data);
            return await Task.FromResult(res);
        }
        public async Task<bool> IsSubRegOfficeNameUnique(Guid subRegOfficeId, string subRegOfficeName)
        {
            var existsdata = (await _dbContext.CmnSubRegOffices.AsNoTracking()
                                .Where(a => subRegOfficeId == Guid.Empty ? a.SubRegOfficeName == subRegOfficeName : a.SubRegOfficeName == subRegOfficeName && a.SubRegOfficeId != subRegOfficeId)
                                .OrderBy(o => o.SubRegOfficeName).AnyAsync());
            return existsdata != false ? true : false;
        }
        public async Task<List<CmnSubRegOfficeByUpozilaIdVM>> GetSubRegOfficeByUpozilaIdAsync(Guid upozilaId)
        {
            try
            {
                var data = await _dbContext.CmnSubRegOffices.AsNoTracking()
                    .Include(i => i.Upozila)
                    .Where(d => d.UpozilaId == upozilaId)
                    .Select(s => new CmnSubRegOfficeByUpozilaIdVM
                    {
                        SubRegOfficeId = s.SubRegOfficeId,
                        SubRegOfficeName = s.SubRegOfficeName,
                        UpozilaId = s.UpozilaId,
                        UpozilaName = s.Upozila.UpozilaName
                    }).OrderBy(o => o.SubRegOfficeName).ThenBy(tb => tb.UpozilaName).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
