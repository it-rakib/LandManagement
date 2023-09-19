using Land.Application.Contracts.Persistence;
using Land.Application.Features.RackNo.Queries.GetAllRackNoListByAlmirahId;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class RackNoRepository : BaseRepository<RackNoInfo>, IRackNoRepository
    {
        public RackNoRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<RackNoListByAlmirahIdVm>> GetAllRackNoListByAlmirahId(Guid almirahId)
        {
            try
            {
                var data = _dbContext.RackNoInfos.AsNoTracking()
                                        .Include(i => i.AlmirahNoInfo)
                                        .Where(d => d.AlmirahNoInfoId == almirahId)
                                        .Select(s => new RackNoListByAlmirahIdVm
                                        {
                                            RackNoInfoId = s.RackNoInfoId,
                                            RackNoInfoName = s.RackNoInfoName,
                                            AlmirahNoInfoId = s.AlmirahNoInfoId,
                                            AlmirahNoInfoName = s.AlmirahNoInfo.AlmirahNoInfoName
                                        }).OrderBy(o => o.RackNoInfoName).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
