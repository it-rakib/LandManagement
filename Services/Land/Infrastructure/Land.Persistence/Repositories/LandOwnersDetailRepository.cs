using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryPersonGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using System.Linq;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryCompanyGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerMouzaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId;

namespace Land.Persistence.Repositories
{
    public class LandOwnersDetailRepository : BaseRepository<LandOwnersDetail>, ILandOwnersDetailRepository
    {
        public LandOwnersDetailRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<GetAllLandSummaryPersonGridVm>> GetAllLandSummaryPersonGridAsync(GridOptions options)
        {
            try
            {
                var query = (from lm in _dbContext.LandMasters
                             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                             from lod in landOwnerDetails.DefaultIfEmpty()
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                             from oi in ownerInfo.DefaultIfEmpty()

                             where (oi.IsCompany == false && lm.IsBayna == false && lm.IsDeleted == false)
                             group new { lod.OwnerInfoId, oi.OwnerInfoName, lod.LandAmount }
                             by new { lm.DeedNo, lod.OwnerInfoId, oi.OwnerInfoName } into g
                             select new GetAllLandSummaryPersonGridVm
                             {
                                 OwnerInfoId = g.Key.OwnerInfoId,
                                 OwnerInfoName = g.Key.OwnerInfoName,
                                 DeedNo = g.Key.DeedNo,
                                 TotalLand = g.Sum(s => s.LandAmount)
                             }).ToList().AsQueryable();

                var data = query != null ?
                        query.GroupBy(g => new
                        {
                            g.OwnerInfoId,
                            g.OwnerInfoName
                        }).Select(s => new GetAllLandSummaryPersonGridVm
                        {
                            OwnerInfoId = s.Key.OwnerInfoId,
                            OwnerInfoName = s.Key.OwnerInfoName,
                            DeedQty = s.Count(),
                            TotalLandAcres = (s.Sum(s => s.TotalLand)) / 100
                        }).ToList().AsQueryable().OrderBy(o => o.OwnerInfoName) : new List<GetAllLandSummaryPersonGridVm>().AsQueryable().OrderBy(o => o.OwnerInfoName);
                var res = KendoGrid<GetAllLandSummaryPersonGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<GridEntity<GetAllLandSummaryCompanyGridVm>> GetAllLandSummaryCompanyGridAsync(GridOptions options)
        {
            try
            {
                var query = (from lm in _dbContext.LandMasters
                             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                             from lod in landOwnerDetails.DefaultIfEmpty()
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                             from oi in ownerInfo.DefaultIfEmpty()

                             where (oi.IsCompany == true && lm.IsBayna == false && lm.IsDeleted == false)
                             group new { lod.OwnerInfoId, oi.OwnerInfoName, lod.LandAmount }
                             by new { lm.DeedNo, lod.OwnerInfoId, oi.OwnerInfoName } into g
                             select new GetAllLandSummaryCompanyGridVm
                             {
                                 OwnerInfoId = g.Key.OwnerInfoId,
                                 OwnerInfoName = g.Key.OwnerInfoName,
                                 DeedNo = g.Key.DeedNo,
                                 TotalLand = g.Sum(s => s.LandAmount)
                             }).ToList().AsQueryable();

                var data = query != null ?
                        query.GroupBy(g => new
                        {
                            g.OwnerInfoId,
                            g.OwnerInfoName
                        }).Select(s => new GetAllLandSummaryCompanyGridVm
                        {
                            OwnerInfoId = s.Key.OwnerInfoId,
                            OwnerInfoName = s.Key.OwnerInfoName,
                            DeedQty = s.Count(),
                            TotalLandAcres = (s.Sum(s => s.TotalLand)) / 100
                        }).ToList().AsQueryable().OrderBy(o => o.OwnerInfoName) : new List<GetAllLandSummaryCompanyGridVm>().AsQueryable().OrderBy(o => o.OwnerInfoName);

                var res = KendoGrid<GetAllLandSummaryCompanyGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<GridEntity<LandOwnerGridVm>> GetAllLandOwnerGridAsync(GridOptions options)
        {
            try
            {
                //var data = (from lm in _dbContext.LandMasters
                //            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                //            from lod in landOwnerDetails.DefaultIfEmpty()
                //            join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                //            from oi in ownerInfo.DefaultIfEmpty()

                //            where lm.IsBayna == false
                //            group new { lod.OwnerInfoId, oi.OwnerInfoName, lod.LandAmount }
                //            by new { lod.OwnerInfoId, oi.OwnerInfoName } into g
                //            select new LandOwnerGridVm
                //            {
                //                OwnerInfoId = g.Key.OwnerInfoId,
                //                OwnerInfoName = g.Key.OwnerInfoName,
                //                DeedQty = g.Count(),
                //                TotalLandAcres = (g.Sum(s => s.LandAmount)) / 100
                //            }).OrderBy(o => o.OwnerInfoName).ToList().AsQueryable();

                var query = (from lm in _dbContext.LandMasters
                             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                             from lod in landOwnerDetails.DefaultIfEmpty()
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                             from oi in ownerInfo.DefaultIfEmpty()

                             where lm.IsBayna == false
                             group new { lod.OwnerInfoId, oi.OwnerInfoName, lod.LandAmount }
                             by new { lm.DeedNo, lod.OwnerInfoId, oi.OwnerInfoName } into g
                             select new LandOwnerGridVm
                             {
                                 OwnerInfoId = g.Key.OwnerInfoId,
                                 OwnerInfoName = g.Key.OwnerInfoName,
                                 DeedNo = g.Key.DeedNo,
                                 TotalLand = g.Sum(s => s.LandAmount)
                             }).ToList().AsQueryable();

                var data = query != null ?
                        query.GroupBy(g => new
                        {
                            g.OwnerInfoId,
                            g.OwnerInfoName
                        }).Select(s => new LandOwnerGridVm
                        {
                            OwnerInfoId = s.Key.OwnerInfoId,
                            OwnerInfoName = s.Key.OwnerInfoName,
                            DeedQty = s.Count(),
                            TotalLandAcres = (s.Sum(s => s.TotalLand)) / 100
                        }).ToList().AsQueryable().OrderBy(o => o.OwnerInfoName) : new List<LandOwnerGridVm>().AsQueryable().OrderBy(o => o.OwnerInfoName);

                var res = KendoGrid<LandOwnerGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<LandOwnerDetailByLandMasterIdMouzaIdVm>> GetAllLandOwnerDetailByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId)
        {
            try
            {
                var data = await _dbContext.LandOwnersDetails
                    .Where(x => x.LandMasterId == landMasterId && x.MouzaId == mouzaId).AsNoTracking()
                    .Include(k => k.Mouza)
                    .Include(l => l.OwnerInfo)
                    .Select(s => new LandOwnerDetailByLandMasterIdMouzaIdVm
                    {
                        LandOwnersDetailId = s.LandOwnersDetailId,
                        LandMasterId = s.LandMasterId,
                        MouzaId = s.MouzaId,
                        MouzaName = s.Mouza.MouzaName,
                        OwnerInfoId = s.OwnerInfoId,
                        OwnerInfoName = s.OwnerInfo.OwnerInfoName,
                        LandAmount = s.LandAmount
                    }).OrderBy(o => o.OwnerInfoName).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>> GetAllLandSummaryOwnerDistrictListByOwnerInfoId(Guid ownerInfoId)
        {
            try
            {
                var query = (from lm in _dbContext.LandMasters
                             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                             from lod in landOwnerDetails.DefaultIfEmpty()
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                             from oi in ownerInfo.DefaultIfEmpty()
                             join cd in _dbContext.CmnDistricts on lm.DistrictId equals cd.DistrictId into district
                             from cd in district.DefaultIfEmpty()

                             where lm.IsBayna == false && lod.OwnerInfoId == ownerInfoId
                             group new { lod.OwnerInfoId, oi.OwnerInfoName, lm.DistrictId, cd.DistrictName, lod.LandAmount }
                             by new { lm.DeedNo, lod.OwnerInfoId, oi.OwnerInfoName, lm.DistrictId, cd.DistrictName } into g
                             select new LandSummaryOwnerDistrictListByOwnerInfoIdVm
                             {
                                 OwnerInfoId = g.Key.OwnerInfoId,
                                 OwnerInfoName = g.Key.OwnerInfoName,
                                 DistrictId = g.Key.DistrictId,
                                 DistrictName = g.Key.DistrictName,
                                 DeedNo = g.Key.DeedNo,
                                 TotalLand = g.Sum(s => s.LandAmount)
                             }).ToList();

                var data = query.GroupBy(g => new
                        {
                            g.OwnerInfoId,
                            g.OwnerInfoName,
                            g.DistrictId,
                            g.DistrictName
                        }).Select(s => new LandSummaryOwnerDistrictListByOwnerInfoIdVm
                        {
                            OwnerInfoId = s.Key.OwnerInfoId,
                            OwnerInfoName = s.Key.OwnerInfoName,
                            DistrictId = s.Key.DistrictId,
                            DistrictName = s.Key.DistrictName,
                            DeedQty = s.Count(),
                            TotalLandAcres = (s.Sum(s => s.TotalLand)) / 100
                        }).OrderBy(o => o.DistrictName).ToList();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>> GetAllLandSummaryOwnerUpozilaListByOwnerInfoId(Guid ownerInfoId)
        {
            try
            {
                var query = (from lm in _dbContext.LandMasters
                             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                             from lod in landOwnerDetails.DefaultIfEmpty()
                             join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                             from oi in ownerInfo.DefaultIfEmpty()
                             join cd in _dbContext.CmnDistricts on lm.DistrictId equals cd.DistrictId into district
                             from cd in district.DefaultIfEmpty()
                             join up in _dbContext.CmnUpozilas on lm.UpozilaId equals up.UpozilaId into upozilas
                             from up in upozilas.DefaultIfEmpty()

                             where lm.IsBayna == false && lod.OwnerInfoId == ownerInfoId
                             group new { lod.OwnerInfoId, oi.OwnerInfoName, lm.DistrictId, cd.DistrictName, lm.UpozilaId, up.UpozilaName, lod.LandAmount }
                             by new { lm.DeedNo, lod.OwnerInfoId, oi.OwnerInfoName, lm.DistrictId, cd.DistrictName, lm.UpozilaId, up.UpozilaName } into g
                             select new LandSummaryOwnerUpozilaListByOwnerInfoIdVm
                             {
                                 OwnerInfoId = g.Key.OwnerInfoId,
                                 OwnerInfoName = g.Key.OwnerInfoName,
                                 DistrictId = g.Key.DistrictId,
                                 DistrictName = g.Key.DistrictName,
                                 UpozilaId = g.Key.UpozilaId,
                                 UpozilaName = g.Key.UpozilaName,
                                 DeedNo = g.Key.DeedNo,
                                 TotalLand = g.Sum(s => s.LandAmount)
                             }).ToList();

                var data = query.GroupBy(g => new
                                    {
                                        g.OwnerInfoId,
                                        g.OwnerInfoName,
                                        g.DistrictId,
                                        g.DistrictName,
                                        g.UpozilaId,
                                        g.UpozilaName
                                    }).Select(s => new LandSummaryOwnerUpozilaListByOwnerInfoIdVm
                                    {
                                        OwnerInfoId = s.Key.OwnerInfoId,
                                        OwnerInfoName = s.Key.OwnerInfoName,
                                        DistrictId = s.Key.DistrictId,
                                        DistrictName = s.Key.DistrictName,
                                        UpozilaId = s.Key.UpozilaId,
                                        UpozilaName = s.Key.UpozilaName,
                                        DeedQty = s.Count(),
                                        TotalLandAcres = (s.Sum(s => s.TotalLand)) / 100
                                    }).OrderBy(o => o.DistrictName).ThenBy(t => t.UpozilaName).ToList();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>> GetAllLandSummaryOwnerMouzaListByOwnerInfoId(Guid ownerInfoId)
        {
            try
            {
                var query = (from lod in _dbContext.LandOwnersDetails
                                  join cm in _dbContext.CmnMouzas on lod.MouzaId equals cm.MouzaId into mouzas
                                  from cm in mouzas.DefaultIfEmpty()

                                  join lm in _dbContext.LandMasters on lod.LandMasterId equals lm.LandMasterId into landMasters
                                  from lm in landMasters.DefaultIfEmpty()

                                  join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                                  from d in district.DefaultIfEmpty()

                                  join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                                  from u in upozila.DefaultIfEmpty()

                                  join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owners
                                  from oi in owners.DefaultIfEmpty()
                                  where (lm.IsBayna == false && lod.OwnerInfoId == ownerInfoId)
                                  group new
                                  {
                                      lod.OwnerInfoId,
                                      oi.OwnerInfoName,
                                      lm.DistrictId,
                                      d.DistrictName,
                                      lm.UpozilaId,
                                      u.UpozilaName,
                                      lod.MouzaId,
                                      cm.MouzaName,
                                      lod.LandAmount
                                  }
                                  by new
                                  {
                                      lod.OwnerInfoId,
                                      oi.OwnerInfoName,
                                      lm.DistrictId,
                                      d.DistrictName,
                                      lm.UpozilaId,
                                      u.UpozilaName,
                                      lod.MouzaId,
                                      cm.MouzaName,
                                      lm.DeedNo
                                  } into g
                                  select new LandSummaryOwnerMouzaListByOwnerInfoIdVm
                                  {
                                      OwnerInfoId = g.Key.OwnerInfoId,
                                      OwnerInfoName = g.Key.OwnerInfoName,
                                      DistrictId = g.Key.DistrictId,
                                      DistrictName = g.Key.DistrictName,
                                      UpozilaId = g.Key.UpozilaId,
                                      UpozilaName = g.Key.UpozilaName,
                                      MouzaId = g.Key.MouzaId,
                                      MouzaName = g.Key.MouzaName,
                                      DeedNo = g.Key.DeedNo,
                                      TotalLand = g.Sum(c => c.LandAmount)
                                  }).ToList();

                var data = query.GroupBy(g => new
                {
                    g.OwnerInfoId,
                    g.OwnerInfoName,
                    g.DistrictId,
                    g.DistrictName,
                    g.UpozilaId,
                    g.UpozilaName,
                    g.MouzaId,
                    g.MouzaName
                }).Select(s => new LandSummaryOwnerMouzaListByOwnerInfoIdVm
                {
                    OwnerInfoId = s.Key.OwnerInfoId,
                    OwnerInfoName = s.Key.OwnerInfoName,
                    DistrictId = s.Key.DistrictId,
                    DistrictName = s.Key.DistrictName,
                    UpozilaId = s.Key.UpozilaId,
                    UpozilaName = s.Key.UpozilaName,
                    MouzaId = s.Key.MouzaId,
                    MouzaName = s.Key.MouzaName,
                    DeedQty = s.Count(),
                    TotalLand = (s.Sum(s => s.TotalLand)) / 100
                }).OrderBy(o => o.DistrictName).ThenBy(t => t.UpozilaName).ThenBy(tb => tb.MouzaName).ToList();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<LandSummaryByLandMasterIdVm>> GetAllLandSummaryByLandMasterId(Guid landMasterId)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                            from lod in landOwnerDetails.DefaultIfEmpty()
                            join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into ownerInfo
                            from oi in ownerInfo.DefaultIfEmpty()
                            join cd in _dbContext.CmnDistricts on lm.DistrictId equals cd.DistrictId into district
                            from cd in district.DefaultIfEmpty()
                            join up in _dbContext.CmnUpozilas on lm.UpozilaId equals up.UpozilaId into upozilas
                            from up in upozilas.DefaultIfEmpty()
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into mouzas
                            from m in mouzas.DefaultIfEmpty()

                            where lm.IsBayna == false && lm.LandMasterId == landMasterId
                            select new LandSummaryByLandMasterIdVm
                            {
                                OwnerInfoId = lod.OwnerInfoId,
                                OwnerInfoName = oi.OwnerInfoName,
                                DeedNo = lm.DeedNo,
                                DistrictId = lm.DistrictId,
                                DistrictName = cd.DistrictName,
                                UpozilaId = lm.UpozilaId,
                                UpozilaName = up.UpozilaName,
                                MouzaId = lod.MouzaId,
                                MouzaName = m.MouzaName,
                                LandAmount = lod.LandAmount,
                                EntryDate = lm.EntryDate
                                //EntryDate = GetDate(lm.EntryDate)
                            }).OrderBy(o => o.DistrictName).ToListAsync();

                return await data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        //public static string GetDate(DateTime? date)
        //{
        //    var recivedDate = date != null ? date.ToString("MM/dd/yyyy") : "";
        //    return recivedDate;

        //}
    }
}
