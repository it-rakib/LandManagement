using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class CmnDistrictRepository : BaseRepository<CmnDistrict>, ICmnDistrictRepository
    {
        public CmnDistrictRepository(LANDDBContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<CmnDistrictByDivisionIdVM>> GetDistrictListByDivisionIdAsync(Guid divisionId)
        {
            try
            {
                return await _dbContext.CmnDistricts.AsNoTracking()
                                        .Include(i => i.Division).Where(d => d.DivisionId == divisionId)
                                        .Select(s => new CmnDistrictByDivisionIdVM
                                        {
                                            DistrictId = s.DistrictId,
                                            DistrictName = s.DistrictName,
                                            DivisionId = s.DivisionId,
                                            DivisionName = s.Division.DivisionName
                                        }).OrderBy(o => o.DistrictName).ThenBy(tb => tb.DivisionName).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<GridEntity<CmnDistrictGridVM>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.CmnDistricts.AsNoTracking().Select(s =>
                                new CmnDistrictGridVM
                                {
                                    DistrictId = s.DistrictId,
                                    DistrictName = s.DistrictName,
                                    DivisionId = s.DivisionId,
                                    DivisionName = s.Division.DivisionName
                                }).OrderBy(o => o.DistrictName).AsQueryable();
            var res = KendoGrid<CmnDistrictGridVM>.DataSource(options, data);
            return await Task.FromResult(res);
        }
        public async Task<bool> IsDistrictNameUnique(Guid districtId, string districtName)
        {
            var existsdata = (await _dbContext.CmnDistricts.AsNoTracking()
                                .Where(a => districtId == Guid.Empty ? a.DistrictName == districtName : a.DistrictName == districtName && a.DistrictId != districtId)
                                .OrderBy(o => o.DistrictName).AnyAsync());
            return existsdata != false ? true : false;
        }
    }
}
