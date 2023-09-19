using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;

namespace Land.Persistence.Repositories
{
    public class SheetNoInfoRepository : BaseRepository<SheetNoInfo>, ISheetNoInfoRepository
    {
        public SheetNoInfoRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        //public async Task<List<GetAllSheetNoInfoListVm>> GetAllSheetNoInfos()
        //{
        //    try
        //    {
        //        var data = await _dbContext.SheetNoInfos.AsNoTracking()
        //            .Select(s => new GetAllSheetNoInfoListVm
        //            {
        //                SheetNoInfoId = s.SheetNoInfoId,
        //                SheetNo = s.SheetNo
        //            }).OrderBy(o=>o.SheetNo).ToListAsync();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
    }
}
