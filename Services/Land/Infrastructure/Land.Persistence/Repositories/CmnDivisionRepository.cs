using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class CmnDivisionRepository : BaseRepository<CmnDivision>, ICmnDivisionRepository
    {
        public CmnDivisionRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<GetAllCmnDivisionGridVM>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.CmnDivisions.AsNoTracking().Select(s =>
                                new GetAllCmnDivisionGridVM
                                {
                                    DivisionId = s.DivisionId,
                                    DivisionName= s.DivisionName
                                }).OrderBy(o => o.DivisionName).AsQueryable();
            var res = KendoGrid<GetAllCmnDivisionGridVM>.DataSource(options, data);
            return await Task.FromResult(res);

        }
        public async Task<bool> IsDivisionNameUnique(Guid divisionId, string divisionName)
        {
            var existsdata = (await _dbContext.CmnDivisions.AsNoTracking().Where(a => divisionId == Guid.Empty ? a.DivisionName == divisionName : a.DivisionName == divisionName && a.DivisionId != divisionId).OrderBy(o => o.DivisionName).AnyAsync());
            return existsdata != false ? true : false;
        }
    }
}
