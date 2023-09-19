using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;

namespace Land.Persistence.Repositories
{
    public class AlmirahNoRepository : BaseRepository<AlmirahNoInfo>, IAlmirahNoRepository
    {
        public AlmirahNoRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
    }
}
