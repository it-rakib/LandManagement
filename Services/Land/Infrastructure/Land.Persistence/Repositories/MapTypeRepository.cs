using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;

namespace Land.Persistence.Repositories
{
    public class MapTypeRepository : BaseRepository<MapType>, IMapTypeRepository
    {
        public MapTypeRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
    }
}
