using Common.Service.Repositories;
using Land.Domain.Models;

namespace Land.Application.Contracts.Persistence
{
    public interface ISheetNoInfoRepository : IAsyncRepository<SheetNoInfo>
    {
        //Task<List<GetAllSheetNoInfoListVm>> GetAllSheetNoInfos();
    }
}
