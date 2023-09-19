using Common.Service.Repositories;
using Land.Domain.Models;

namespace Land.Application.Contracts.Persistence
{
    public interface IAlmirahNoRepository : IAsyncRepository<AlmirahNoInfo>
    {
    }
}
