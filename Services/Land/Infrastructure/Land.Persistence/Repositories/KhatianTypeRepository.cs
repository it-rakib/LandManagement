using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;

namespace Land.Persistence.Repositories
{
    public class KhatianTypeRepository : BaseRepository<KhatianType>, IKhatiyanTypeRepository
    {
        public KhatianTypeRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
    }
}
