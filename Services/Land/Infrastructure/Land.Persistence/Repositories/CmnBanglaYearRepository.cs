using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;

namespace Land.Persistence.Repositories
{
    public class CmnBanglaYearRepository : BaseRepository<CmnBanglaYear>, ICmnBanglaYearRepository
    {
        public CmnBanglaYearRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
    }
}
