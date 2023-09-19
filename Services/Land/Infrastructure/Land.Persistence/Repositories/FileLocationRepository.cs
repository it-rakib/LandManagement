using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class FileLocationRepository : BaseRepository<FileLocationMaster>, IFileLocationRepository
    {
        public FileLocationRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsFileNoUnique(Guid fileLocationMasterId, Guid fileNoInfoId)
        {
            try
            {
                var existsdata = (await _dbContext.FileLocationMasters.AsNoTracking()
                                .Where(a => fileLocationMasterId == Guid.Empty ? a.FileNoInfoId == fileNoInfoId : a.FileNoInfoId == fileNoInfoId && a.FileLocationMasterId != fileLocationMasterId)
                                .AnyAsync());
                return existsdata != false ? true : false;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<FileLocationMaster> GetFileLocationMasterById(Guid fileLocationMasterId)
        {
            try
            {
                return await _dbContext.FileLocationMasters.Where(s => s.FileLocationMasterId == fileLocationMasterId).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<FileLocationMaster> UpdateFileLocationMaster(FileLocationMaster fileLocationMaster)
        {
            Guid fileLocationMasterId = fileLocationMaster.FileLocationMasterId;

            var fileLocationDetails = fileLocationMaster.FileLocationDetails.ToList();
            var fldIds = fileLocationDetails.Select(s => s.FileLocationDetailId).ToList();
            RemoveFileLocationDetails(fldIds, fileLocationMasterId);

            _dbContext.Entry(fileLocationMaster).State = EntityState.Modified;
            _dbContext.FileLocationDetails.UpdateRange(fileLocationDetails);
            await _dbContext.SaveChangesAsync();
            return fileLocationMaster;
        }

        public void RemoveFileLocationDetails(List<Guid> fldIds, Guid fileLocationMasterId)
        {
            var removeData = _dbContext.FileLocationDetails.Where(s => s.FileLocationMasterId == fileLocationMasterId && !fldIds.Contains(s.FileLocationDetailId)).ToList();
            _dbContext.FileLocationDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }

        public async Task<GridEntity<FileLocationGridVm>> GetAllPagingAsync(GridOptions options)
        {
            try
            {
                var data = (from flm in _dbContext.FileLocationMasters
                            where flm.IsDeleted == false
                            join fni in _dbContext.FileNoInfos on flm.FileNoInfoId equals fni.FileNoInfoId into fileno
                            from fni in fileno.DefaultIfEmpty()
                            join fci in _dbContext.FileCodeInfos on fni.FileCodeInfoId equals fci.FileCodeInfoId into filecode
                            from fci in filecode.DefaultIfEmpty()
                            join rni in _dbContext.RackNoInfos on flm.RackNoInfoId equals rni.RackNoInfoId into rack
                            from rni in rack.DefaultIfEmpty()
                            join ani in _dbContext.AlmirahNoInfos on rni.AlmirahNoInfoId equals ani.AlmirahNoInfoId into almirah
                            from ani in almirah.DefaultIfEmpty()
                            join fld in _dbContext.FileLocationDetails on flm.FileLocationMasterId equals fld.FileLocationMasterId into loc
                            from fld in loc.DefaultIfEmpty()
                            join lm in _dbContext.LandMasters on fld.LandMasterId equals lm.LandMasterId into land
                            from lm in land.DefaultIfEmpty()

                            group new
                            {
                                fld.FileLocationMasterId,
                                fci.FileCodeInfoId,
                                fci.FileCodeInfoName,
                                fni.FileNoInfoId,
                                fni.FileNoInfoName,
                                ani.AlmirahNoInfoId,
                                ani.AlmirahNoInfoName,
                                rni.RackNoInfoId,
                                rni.RackNoInfoName,
                                lm.DeedNo,
                                flm.IsDeleted
                            //    flm.Remarks
                            }
                            by new
                            {
                                fld.FileLocationMasterId,
                                fci.FileCodeInfoId,
                                fci.FileCodeInfoName,
                                fni.FileNoInfoId,
                                fni.FileNoInfoName,
                                ani.AlmirahNoInfoId,
                                ani.AlmirahNoInfoName,
                                rni.RackNoInfoId,
                                rni.RackNoInfoName,
                                flm.Remarks,
                                flm.IsDeleted

                            } into g

                            select new FileLocationGridVm
                            {
                                FileLocationMasterId = g.Key.FileLocationMasterId,
                                FileCodeInfoId = g.Key.FileCodeInfoId,
                                FileCodeInfoName = g.Key.FileCodeInfoName,
                                FileNoInfoId = g.Key.FileNoInfoId,
                                FileNoInfoName = g.Key.FileNoInfoName,
                                AlmirahNoInfoId = g.Key.AlmirahNoInfoId,
                                AlmirahNoInfoName = g.Key.AlmirahNoInfoName,
                                RackNoInfoId = g.Key.RackNoInfoId,
                                RackNoInfoName = g.Key.RackNoInfoName,
                                DeedNo = string.Join(", ", g.Select(i => i.DeedNo)),
                                Remarks = g.Key.Remarks,
                                IsDeleted = g.Key.IsDeleted
                                //CreatedAt = (DateTime)g.Key.CreatedAt
                            }).OrderByDescending(o=> o.FileCodeInfoName).ToList().AsQueryable().AsNoTracking();
                var res = KendoGrid<FileLocationGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<FileLocationDetailListByFileLocationMasterIdVm>> GetAllFileLocationDetailListByFileLocationMasterId(Guid fileLocationMasterId)
        {
            try
            {
                var data = await _dbContext.FileLocationDetails.Where(x => x.FileLocationMasterId == fileLocationMasterId).AsNoTracking()
                                            .Include(j => j.LandMaster)
                                            .Select(s => new FileLocationDetailListByFileLocationMasterIdVm
                                            {
                                                FileLocationDetailId = s.FileLocationDetailId,
                                                FileLocationMasterId = s.FileLocationMasterId,
                                                LandMasterId = s.LandMasterId,
                                                DeedNo = s.LandMaster.DeedNo
                                            }).OrderBy(o => o.DeedNo).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<FileLocationDetailListVm>> GetAllFileLocationDetailList()
        {
            try
            {
                var data = await _dbContext.FileLocationDetails.AsNoTracking()
                                            .Include(j => j.LandMaster)
                                            .Select(s => new FileLocationDetailListVm
                                            {
                                                FileLocationDetailId = s.FileLocationDetailId,
                                                FileLocationMasterId = s.FileLocationMasterId,
                                                LandMasterId = s.LandMasterId,
                                                DeedNo = s.LandMaster.DeedNo
                                            }).OrderBy(o => o.DeedNo).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
