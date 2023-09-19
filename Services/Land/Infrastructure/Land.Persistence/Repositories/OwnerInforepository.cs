using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class OwnerInforepository : BaseRepository<OwnerInfo>, IOwnerInfoRepository
    {
        public OwnerInforepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<OwnerInfoGridVm>> GetAllPagingAsync(GridOptions options)
        {
            var data = _dbContext.OwnerInfos.AsNoTracking().Where(f=> f.IsActive == true).Select(s =>
                                new OwnerInfoGridVm
                                {
                                    OwnerInfoId = s.OwnerInfoId,
                                    OwnerInfoName = s.OwnerInfoName,
                                    IsCompany = s.IsCompany,
                                    IsActive = s.IsActive,
                                    Status = s.IsCompany == true ? "Company" : "Person"
                                }).OrderBy(o => o.OwnerInfoName).AsQueryable();
            var res = KendoGrid<OwnerInfoGridVm>.DataSource(options, data);
            return await Task.FromResult(res);
        }
        public async Task<bool> IsOwnerNameUnique(Guid ownerInfoId, string ownerInfoName)
        {
            var existsdata = (await _dbContext.OwnerInfos.AsNoTracking()
                                  .Where(a => ownerInfoId == Guid.Empty ? a.OwnerInfoName == ownerInfoName : a.OwnerInfoName == ownerInfoName && a.OwnerInfoId != ownerInfoId)
                                  .OrderBy(o => o.OwnerInfoName).AnyAsync());
            return existsdata != false ? true : false;
        }
        public async Task<int> GetTotalCompany()
        {
            try
            {

                var query = (from
                             lm in _dbContext.LandMasters.Where(f=> f.IsBayna == false && f.IsDeleted == false)
                             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owners
                             from oi in owners.DefaultIfEmpty()

                             where (oi.IsCompany == true)
                             group new { lod.OwnerInfoId, oi.OwnerInfoName }
                             by new { lod.OwnerInfoId, oi.OwnerInfoName } into g
                             select new
                             {
                                 g.Key.OwnerInfoId,
                                 g.Key.OwnerInfoName
                             }).ToList();

                var data = query.Select(s => new
                                        {
                                            s.OwnerInfoName,
                                            s.OwnerInfoId
                                        }).Count();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<int> GetTotalPerson()
        {
            try
            {
                var query = (from lod in _dbContext.LandOwnersDetails.Where(f=> f.LandMaster.IsDeleted == false)
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owners
                             from oi in owners.DefaultIfEmpty()

                             where (oi.IsCompany == false)
                             group new { lod.OwnerInfoId, oi.OwnerInfoName }
                             by new { lod.OwnerInfoId, oi.OwnerInfoName } into g
                             select new
                             {
                                 g.Key.OwnerInfoId,
                                 g.Key.OwnerInfoName
                             }).ToList();

                var data = query.Select(s => new
                {
                    s.OwnerInfoName,
                    s.OwnerInfoId
                }).Count();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
