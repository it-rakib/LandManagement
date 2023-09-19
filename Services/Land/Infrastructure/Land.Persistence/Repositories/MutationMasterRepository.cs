using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllDagNoListByLandMasterKhatianType;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId;
using Land.Application.Features.CmnDocument;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllHoldingNoList;

namespace Land.Persistence.Repositories
{
    public class MutationMasterRepository : BaseRepository<MutationMaster>, IMutationMasterRepository
    {
        public MutationMasterRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> IsExist(Guid MutationMasterId, string HoldingNo)
        {
            try
            {
                var existsData = (await _dbContext.MutationMasters.Where(f=> f.IsDeleted == false).AsNoTracking()
                    .Where(a => MutationMasterId == Guid.Empty ? a.HoldingNo == HoldingNo : a.HoldingNo == HoldingNo && a.MutationMasterId != MutationMasterId )
                    .OrderBy(o => o.HoldingNo).AnyAsync());
                return existsData != false ? true : false;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<MutationMaster> GetMutationMasterById(Guid MutationMasterId)
        {
            try
            {
                return await _dbContext.MutationMasters.Where(s => s.MutationMasterId == MutationMasterId).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<MutationMaster> UpdateMutationMaster(MutationMaster mutationMaster)
        {
            Guid mutationMasterId = mutationMaster.MutationMasterId;

            var plotWiseMutationDetails = mutationMaster.PlotWiseMutationDetails.ToList();
            var pwmdIds = plotWiseMutationDetails.Select(s => s.PlotWiseMutationDetailId).ToList();
            RemovePlotWiseMutationDetailInfo(pwmdIds, mutationMasterId);

            var ownerWiseMutationDetails = mutationMaster.OwnerWiseMutationDetails.ToList();
            var mdIds = ownerWiseMutationDetails.Select(s => s.OwnerWiseMutationDetailId).ToList();
            RemoveOwnerWiseMutationDetailInfo(mdIds, mutationMasterId);

            _dbContext.Entry(mutationMaster).State = EntityState.Modified;
            _dbContext.PlotWiseMutationDetails.UpdateRange(plotWiseMutationDetails);
            _dbContext.OwnerWiseMutationDetails.UpdateRange(ownerWiseMutationDetails);
            await _dbContext.SaveChangesAsync();

            return mutationMaster;
        }
        public void RemovePlotWiseMutationDetailInfo(List<Guid> pwmdIds, Guid mutationMasterId)
        {
            var removeData = _dbContext.PlotWiseMutationDetails.Where(s => s.MutationMasterId == mutationMasterId && !pwmdIds.Contains(s.PlotWiseMutationDetailId)).ToList();
            _dbContext.PlotWiseMutationDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveOwnerWiseMutationDetailInfo(List<Guid> mdIds, Guid mutationMasterId)
        {
            var removeData = _dbContext.OwnerWiseMutationDetails.Where(s => s.MutationMasterId == mutationMasterId && !mdIds.Contains(s.OwnerWiseMutationDetailId)).ToList();
            _dbContext.OwnerWiseMutationDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public async Task<GridEntity<GetAllMutationMasterGridVm>> GetAllMasterGridAsync(GridOptions options)
        {
            try
            {
                var data = (from mm in _dbContext.MutationMasters
                            where mm.IsDeleted == false

                            join omd in _dbContext.OwnerWiseMutationDetails on mm.MutationMasterId equals omd.MutationMasterId into ownm
                            from omd in ownm.DefaultIfEmpty()

                            join o in _dbContext.OwnerInfos on omd.OwnerInfoId equals o.OwnerInfoId into owner
                            from o in owner.DefaultIfEmpty()

                            join m in _dbContext.CmnMouzas on mm.MouzaId equals m.MouzaId into cmnMouzas
                            from m in cmnMouzas.DefaultIfEmpty()

                            join up in _dbContext.CmnUpozilas on m.UpozilaId equals up.UpozilaId into cmnUpozilas
                            from up in cmnUpozilas.DefaultIfEmpty()

                            join d in _dbContext.CmnDistricts on up.DistrictId equals d.DistrictId into cmnDistricts
                            from d in cmnDistricts.DefaultIfEmpty()

                            join lm in _dbContext.LandMasters on omd.LandMasterId equals lm.LandMasterId into lms
                            from lm in lms.DefaultIfEmpty()

                            join dv in _dbContext.CmnDivisions on mm.DivisionId equals dv.DivisionId into cmnDivisions
                            from dv in cmnDivisions.DefaultIfEmpty()

                            select new GetAllMutationMasterGridVm
                            {
                                LandMasterId = lm.LandMasterId,
                                MutationMasterId = mm.MutationMasterId,
                                DivisionId = mm.DivisionId,
                                DivisionName = dv.DivisionName,
                                DistrictId = mm.DistrictId,
                                DistrictName = d.DistrictName,
                                UpozilaId = mm.UpozilaId,
                                UpozilaName = up.UpozilaName,
                                MouzaId = mm.MouzaId,
                                MouzaName = m.MouzaName,
                                OwnerInfoId = o.OwnerInfoId,
                                OwnerInfoName = o.OwnerInfoName,
                                MutationApplicationNo = mm.MutationApplicationNo,
                                MutationApplicationDate = mm.MutationApplicationDate,
                                CaseNo = mm.CaseNo,
                                Dcrno = mm.Dcrno,
                                DeedNo = lm.DeedNo,
                                MutationKhatianNo = mm.MutationKhatianNo,
                                HoldingNo = mm.HoldingNo,
                                OwnerLandAmount = omd.OwnerLandAmount,
                                OwnerMutatedLandAmount = omd.OwnerMutatedLandAmount,
                                IsRecorded = mm.IsRecorded,
                                Remarks = mm.Remarks,
                                FileRemarks = mm.FileRemarks,
                                CreatedAt = mm.CreatedAt,
                                IsDeleted = mm.IsDeleted,
                                FilesVm = _dbContext.CmnDocumentFiles.Where(s => s.ModuleMasterId == mm.MutationMasterId && s.ModuleName == "Land").AsNoTrackingWithIdentityResolution()
                                                .Select(f => new FilesVm()
                                                {
                                                    name = f.FileName,
                                                    size = (int)f.FileSize,
                                                    extension = f.FileExtension,
                                                    docId = f.DocumentId,
                                                    fileUniq = f.FileUniqueName
                                                }).ToList()
                            }).OrderBy(o => o.HoldingNo).ThenByDescending(p=> p.CreatedAt).ToList().AsQueryable().AsNoTracking();
                var res = KendoGrid<GetAllMutationMasterGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<List<PlotWiseMutationDetailListByMutationMasterIdVm>> GetAllPlotWiseMutationDetailListByMutationMasterId(Guid mutationMasterId)
        {
            try
            {
                var data = await _dbContext.PlotWiseMutationDetails.Where(x => x.MutationMasterId == mutationMasterId).AsNoTracking()
                    .Include(i => i.LandMaster)
                    .Select(s => new PlotWiseMutationDetailListByMutationMasterIdVm
                    {
                        PlotWiseMutationDetailId = s.PlotWiseMutationDetailId,
                        MutationMasterId = s.MutationMasterId,
                        LandMasterId = s.LandMasterId,
                        DeedNo = s.LandMaster.DeedNo,
                        KhatianTypeId = s.KhatianTypeId,
                        KhatianTypeName = _dbContext.KhatianTypes.FirstOrDefault(w => w.KhatianTypeId == s.KhatianTypeId).KhatianTypeName,
                        KhatianNo = s.KhatianNo,
                        DagNo = s.DagNo,
                        PlotWiseMutationLandAmount = s.PlotWiseMutationLandAmount
                    }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<List<OwnerWiseMutationDetailListByMutationMasterIdVm>> GetAllOwnerWiseMutationDetailListByMutationMasterId(Guid mutationMasterId)
        {
            try
            {
                var data = await _dbContext.OwnerWiseMutationDetails.Where(x => x.MutationMasterId == mutationMasterId).AsNoTracking()
                    .Include(i => i.LandMaster)
                    .Select(s => new OwnerWiseMutationDetailListByMutationMasterIdVm
                    {
                        OwnerWiseMutationDetailId = s.OwnerWiseMutationDetailId,
                        MutationMasterId = s.MutationMasterId,
                        LandMasterId = s.LandMasterId,
                        KhatianTypeId = s.KhatianTypeId,
                        KhatianTypeName = _dbContext.KhatianTypes.FirstOrDefault(w => w.KhatianTypeId == s.KhatianTypeId).KhatianTypeName,
                        DeedNo = s.LandMaster.DeedNo,
                        OwnerInfoId = s.OwnerInfoId,
                        OwnerInfoName = _dbContext.OwnerInfos.Where(x => x.OwnerInfoId == s.OwnerInfoId).AsNoTracking().FirstOrDefault().OwnerInfoName,
                        OwnerLandAmount = s.OwnerLandAmount,
                        OwnerMutatedLandAmount = s.OwnerMutatedLandAmount
                    }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<decimal> GetTotalMutatedLand()
        {
            try
            {
                //var totalMutatedLandDecimal = _dbContext.PlotWiseMutationDetails.AsNoTracking().Sum(x => x.PlotWiseMutationLandAmount);
                var totalMutatedLandDecimal = _dbContext.OwnerWiseMutationDetails.Where(f=> f.MutationMaster.IsDeleted == false).AsNoTracking().Sum(x => x.OwnerMutatedLandAmount);
                //var result = totalMutatedLandDecimal != null ? totalMutatedLandDecimal : 0;
                var totalMutatedLandAcres = totalMutatedLandDecimal / 100;
                return (decimal)totalMutatedLandAcres;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<decimal> GetTotalMutatedLandByLandMasterIdKhatianTypeId(Guid landMasterId, Guid khatianTypeId)
        {
            try
            {
                var totalMutatedLandDecimal = _dbContext.PlotWiseMutationDetails.Where(w => w.LandMasterId == landMasterId && w.KhatianTypeId == khatianTypeId)
                                              .AsNoTracking().Sum(x => x.PlotWiseMutationLandAmount);
                //var result = totalMutatedLandDecimal != null ? totalMutatedLandDecimal : 0;
                return totalMutatedLandDecimal;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<List<MutatedDeedNoListVm>> GetAllMutatedDeedNoList()
        {
            try
            {
                var query = (from pwmd in _dbContext.PlotWiseMutationDetails
                             join lm in _dbContext.LandMasters on pwmd.LandMasterId equals lm.LandMasterId into landMaster
                             from lm in landMaster.DefaultIfEmpty()
                             where lm.IsBayna == false
                             select new MutatedDeedNoListVm
                             {
                                 LandMasterId = pwmd.LandMasterId,
                                 DeedNo = lm.DeedNo,
                                 Status = lm.LandMasterId == pwmd.LandMasterId ? "Mutated Deed" : "Non-Mutated Deed"
                             }).ToList();
                var data = query.GroupBy(g => new
                {
                    g.LandMasterId,
                    g.DeedNo,
                    g.Status
                }).Select(s => new MutatedDeedNoListVm
                {
                    LandMasterId = s.Key.LandMasterId,
                    DeedNo = s.Key.DeedNo,
                    Status = s.Key.Status
                }).OrderBy(o => o.DeedNo).ToList();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<List<DagNoListByLandMasterKhatianTypeVm>> GetAllDagNoListByLandMasterKhatianType(Guid landMasterId, Guid khatianTypeId)
        {
            try
            {
                var data = (from pwm in _dbContext.PlotWiseMutationDetails
                             where (pwm.LandMasterId == landMasterId && pwm.KhatianTypeId == khatianTypeId)
                             group new { pwm.DagNo }
                             by new { pwm.DagNo } into g
                             select new DagNoListByLandMasterKhatianTypeVm
                             {
                                 DagNo = g.Key.DagNo
                             }).OrderBy(o => o.DagNo).AsNoTracking().ToList();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<decimal> GetTotalPlotWiseMutatedLandAmountByLandMasterKhatianTypeDagNo(Guid landMasterId, Guid khatianTypeId, string dagNo)
        {
            try
            {
                var totalMutatedLandDecimal = _dbContext.PlotWiseMutationDetails
                                                        .Where(w => w.LandMasterId == landMasterId 
                                                                    && w.KhatianTypeId == khatianTypeId
                                                                    && w.DagNo == dagNo)
                                              .AsNoTracking().Sum(x => x.PlotWiseMutationLandAmount);
                
                return totalMutatedLandDecimal;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>> GetAllTransferedOwnerInfoByLandMasterKhatianTypeId(Guid landMasterId, Guid khatianTypeId)
        {
            try
            {
                var data = (from pwm in _dbContext.OwnerWiseMutationDetails
                            join oi in _dbContext.OwnerInfos on pwm.OwnerInfoId equals oi.OwnerInfoId into ownerInfos
                            from oi in ownerInfos.DefaultIfEmpty()

                            where (pwm.LandMasterId == landMasterId && pwm.KhatianTypeId == khatianTypeId)
                            group new { pwm.OwnerInfoId, oi.OwnerInfoName }
                            by new { pwm.OwnerInfoId, oi.OwnerInfoName } into g
                            select new TransferedOwnerInfoByLandMasterKhatianTypeIdVm
                            {
                                TransferedOwnerInfoId = g.Key.OwnerInfoId,
                                TransferedOwnerInfoName = g.Key.OwnerInfoName
                            }).OrderBy(o => o.TransferedOwnerInfoName).AsNoTracking().ToList();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<decimal> GetTotalOwnerWiseMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid landMasterId, Guid khatianTypeId, Guid ownerInfoId)
        {
            try
            {
                var totalMutatedLandDecimal = _dbContext.OwnerWiseMutationDetails
                                                        .Where(w => w.LandMasterId == landMasterId
                                                                    && w.KhatianTypeId == khatianTypeId
                                                                    && w.OwnerInfoId == ownerInfoId)
                                              .AsNoTracking().Sum(x => x.OwnerMutatedLandAmount);

                return totalMutatedLandDecimal ?? 0;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<HoldingNoListVm>> GetAllHoldingNo()
        {
            try
            {
                var data = await _dbContext.MutationMasters.AsNoTracking()
                    .Where(f => f.IsDeleted == false)
                    .Select(s => new HoldingNoListVm
                    {
                        MutationMasterId = s.MutationMasterId,
                        HoldingNo = s.HoldingNo
                    }).OrderBy(o=> o.HoldingNo).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
