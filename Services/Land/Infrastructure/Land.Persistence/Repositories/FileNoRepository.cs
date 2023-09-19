using Land.Application.Contracts.Persistence;
using Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class FileNoRepository : BaseRepository<FileNoInfo>, IFileNoRepository
    {
        public FileNoRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<FileNoListByFileCodeIdVm>> GetFileNoListByFileCodeId(Guid fileCodeId)
        {
            try
            {
                var data = _dbContext.FileNoInfos.AsNoTracking()
                                        .Include(i => i.FileCodeInfo)
                                        .Where(d => d.FileCodeInfoId == fileCodeId)
                                        .Select(s => new FileNoListByFileCodeIdVm
                                        {
                                            FileNoInfoId = s.FileNoInfoId,
                                            FileNoInfoName = s.FileNoInfoName,
                                            FileCodeInfoId = s.FileCodeInfoId,
                                            FileCodeInfoName = s.FileCodeInfo.FileCodeInfoName
                                        }).OrderBy(o => o.FileNoInfoName).ToListAsync();
                return await data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
