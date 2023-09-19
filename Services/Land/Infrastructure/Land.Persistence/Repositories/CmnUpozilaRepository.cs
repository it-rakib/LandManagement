using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class CmnUpozilaRepository : BaseRepository<CmnUpozila>, ICmnUpozilaRepository
    {
        public CmnUpozilaRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<CmnUpozilaGridVM>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.CmnUpozilas.AsNoTracking().Select(s =>
                                new CmnUpozilaGridVM
                                {
                                    UpozilaId = s.UpozilaId,
                                    UpozilaName = s.UpozilaName,
                                    DistrictId = s.DistrictId,
                                    DistrictName = s.District.DistrictName,
                                    DivisionId = s.District.Division.DivisionId,
                                    DivisionName = s.District.Division.DivisionName

                                }).OrderBy(o => o.UpozilaName).AsQueryable();
            var res = KendoGrid<CmnUpozilaGridVM>.DataSource(options, data);
            return await Task.FromResult(res);
        }
        public async Task<bool> IsUpozilaNameUnique(Guid upozilaId, string upozilaName)
        {
            var existsdata = (await _dbContext.CmnUpozilas.AsNoTracking()
                                .Where(a => upozilaId == Guid.Empty ? a.UpozilaName == upozilaName : a.UpozilaName == upozilaName && a.UpozilaId != upozilaId)
                                .OrderBy(o => o.UpozilaName).AnyAsync());
            return existsdata != false ? true : false;
        }
        public async Task<List<CmnUpozilaByDistrictIdVM>> GetUpozilaByDistrictIdAsync(Guid districtId)
        {
            try
            {
                return await _dbContext.CmnUpozilas.AsNoTracking()
                                        .Where(d => d.DistrictId == districtId)
                                        .Select(s => new CmnUpozilaByDistrictIdVM
                                        {
                                            UpozilaId = s.UpozilaId,
                                            UpozilaName = s.UpozilaName,
                                            DistrictId = s.DistrictId,
                                            DistrictName = s.District.DistrictName
                                        }).OrderBy(o => o.UpozilaName).ThenBy(tb => tb.DistrictName).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
