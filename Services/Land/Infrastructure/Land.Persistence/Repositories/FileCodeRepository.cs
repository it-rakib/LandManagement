using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.FileCode.Queries.GetAllFileCodeGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class FileCodeRepository : BaseRepository<FileCodeInfo>, IFileCodeRepository
    {
        public FileCodeRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<GridEntity<GetAllFileCodeGridVm>> GetAllPagingAsync(GridOptions options)
        {
            try
            {
                var data = _dbContext.FileCodeInfos.AsNoTracking()
                    .Where(f=> f.IsActive == true)
                    .Select(s => new GetAllFileCodeGridVm
                    {
                        FileCodeInfoId = s.FileCodeInfoId,
                        FileCodeInfoName = s.FileCodeInfoName,
                        FileCodeInfoFullName = s.FileCodeInfoFullName,
                        IsActive = s.IsActive,
                    }).OrderBy(o => o.FileCodeInfoName).AsQueryable();
                var res = KendoGrid<GetAllFileCodeGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
                    
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<bool> IsFileCodeNameUnique(Guid fileCodeId, string fileCodeName)
        {
            var existsdata = (await _dbContext.FileCodeInfos.AsNoTracking().Where(a => fileCodeId == Guid.Empty ? a.FileCodeInfoName == fileCodeName : a.FileCodeInfoName == fileCodeName && a.FileCodeInfoId != fileCodeId).OrderBy(o => o.FileCodeInfoName).AnyAsync());
            return existsdata != false ? true : false;
        }
    }
}
