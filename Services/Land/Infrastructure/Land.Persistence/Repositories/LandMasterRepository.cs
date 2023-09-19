using Common.Service.CommonEntities.KendoGrid;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDocument;
using Land.Application.Features.LandMasterInfo.Queries.GetAllBayaDeedDetailListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoByOwnerInfoId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoList;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoListByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterIdMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandDetailListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMasterGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandOwnerListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSalerInfoListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByUpozilaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictList;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryFileDeedOwnerCommonGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByUpozilaIdGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryOwnerMouzaCommonGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpazilaByUpazilaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaByDistrictIdGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandSaleDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandTransferDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandSaleDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandTransferDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllUpozilaByDistrictIdList;
using Land.Application.Features.LandMasterInfo.Queries.GetLandInformationsByDeedNo;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class LandMasterRepository : BaseRepository<LandMaster>, ILandMasterRepository
    {
        public LandMasterRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<LandMaster> GetLandMasterById(Guid LandMasterId)
        {
            try
            {
                return await _dbContext.LandMasters.Where(s => s.LandMasterId == LandMasterId).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        #region Land Master Update
        public async Task<LandMaster> UpdateLandMaster(LandMaster landMaster)
        {
            Guid landMasterId = landMaster.LandMasterId;

            var plotWiseLandSaleDetails = landMaster.PlotWiseLandSaleDetails.ToList();
            var pwlsdIds = plotWiseLandSaleDetails.Select(s => s.PlotWiseLandSaleDetailId).ToList();
            RemovePlotWiseLandSaleDetails(pwlsdIds, landMasterId);

            var ownerWiseLandSaleDetails = landMaster.OwnerWiseLandSaleDetails.ToList();
            var owlsdIds = ownerWiseLandSaleDetails.Select(s => s.OwnerWiseLandSaleDetailId).ToList();
            RemoveOwnerWiseLandSaleDetails(owlsdIds, landMasterId);

            var plotWiseLandTransferDetails = landMaster.PlotWiseLandTransferDetails.ToList();
            var pwltdIds = plotWiseLandTransferDetails.Select(s => s.PlotWiseLandTransferDetailId).ToList();
            RemovePlotWiseLandTransferDetails(pwltdIds, landMasterId);

            var ownerWiseLandTransferDetails = landMaster.OwnerWiseLandTransferDetails.ToList();
            var owltdIds = ownerWiseLandTransferDetails.Select(s => s.OwnerWiseLandTransferDetailId).ToList();
            RemoveOwnerWiseLandTransferDetails(owltdIds, landMasterId);

            var landMasterOwnerRelation = landMaster.LandMasterOwnerRelations.ToList();
            var lmoIds = landMasterOwnerRelation.Select(s => s.LandMasterOwnerRelationId).ToList();
            RemoveLandMasterOwnerRelation(lmoIds, landMasterId);

            var landSalersInfos = landMaster.LandSalersInfos.ToList();
            var lsIds = landSalersInfos.Select(s => s.SalersInfoId).ToList();
            RemovelandSalersInfos(lsIds, landMasterId);

            var khatianDetails = landMaster.KhatianDetails.ToList();
            var kdIds = khatianDetails.Select(s => s.KhatianDetailId).ToList();
            RemoveKhatianDetailInfo(kdIds, landMasterId);

            var ownerDetails = landMaster.LandOwnersDetails.ToList();
            var odIds = ownerDetails.Select(s => s.LandOwnersDetailId).ToList();
            RemoveOwnerDetailInfo(odIds, landMasterId);

            var BayaDeedDetails = landMaster.BayaDeedDetails.ToList();
            var bddIds = BayaDeedDetails.Select(s => s.BayaDeedDetailId).ToList();
            RemoveBayaDeedDetailInfo(bddIds, landMasterId);

            _dbContext.Entry(landMaster).State = EntityState.Modified;
            _dbContext.PlotWiseLandSaleDetails.UpdateRange(plotWiseLandSaleDetails);
            _dbContext.OwnerWiseLandSaleDetails.UpdateRange(ownerWiseLandSaleDetails);
            _dbContext.PlotWiseLandTransferDetails.UpdateRange(plotWiseLandTransferDetails);
            _dbContext.OwnerWiseLandTransferDetails.UpdateRange(ownerWiseLandTransferDetails);
            _dbContext.LandMasterOwnerRelations.UpdateRange(landMasterOwnerRelation);
            _dbContext.LandSalersInfos.UpdateRange(landSalersInfos);
            _dbContext.KhatianDetails.UpdateRange(khatianDetails);
            _dbContext.LandOwnersDetails.UpdateRange(ownerDetails);
            _dbContext.BayaDeedDetails.UpdateRange(BayaDeedDetails);
            await _dbContext.SaveChangesAsync();
            return landMaster;
        }

        public void RemovePlotWiseLandSaleDetails(List<Guid> pwlsdIds, Guid landMasterId)
        {
            var removeData = _dbContext.PlotWiseLandSaleDetails.Where(s => s.LandMasterId == landMasterId && !pwlsdIds.Contains(s.PlotWiseLandSaleDetailId)).ToList();
            _dbContext.PlotWiseLandSaleDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveOwnerWiseLandSaleDetails(List<Guid> owlsdIds, Guid landMasterId)
        {
            var removeData = _dbContext.OwnerWiseLandSaleDetails.Where(s => s.LandMasterId == landMasterId && !owlsdIds.Contains(s.OwnerWiseLandSaleDetailId)).ToList();
            _dbContext.OwnerWiseLandSaleDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemovePlotWiseLandTransferDetails(List<Guid> pwltdIds, Guid landMasterId)
        {
            var removeData = _dbContext.PlotWiseLandTransferDetails.Where(s => s.LandMasterId == landMasterId && !pwltdIds.Contains(s.PlotWiseLandTransferDetailId)).ToList();
            _dbContext.PlotWiseLandTransferDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveOwnerWiseLandTransferDetails(List<Guid> owltdIds, Guid landMasterId)
        {
            var removeData = _dbContext.OwnerWiseLandTransferDetails.Where(s => s.LandMasterId == landMasterId && !owltdIds.Contains(s.OwnerWiseLandTransferDetailId)).ToList();
            _dbContext.OwnerWiseLandTransferDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveLandMasterOwnerRelation(List<Guid> lmoIds, Guid landMasterId)
        {
            var removeData = _dbContext.LandMasterOwnerRelations.Where(s => s.LandMasterId == landMasterId && !lmoIds.Contains(s.LandMasterOwnerRelationId)).ToList();
            _dbContext.LandMasterOwnerRelations.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemovelandSalersInfos(List<Guid> lsIds, Guid landMasterId)
        {
            var removeData = _dbContext.LandSalersInfos.Where(s => s.LandMasterId == landMasterId && !lsIds.Contains(s.SalersInfoId)).ToList();
            _dbContext.LandSalersInfos.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveKhatianDetailInfo(List<Guid> kdIds, Guid landMasterId)
        {
            var removeData = _dbContext.KhatianDetails.Where(s => s.LandMasterId == landMasterId && !kdIds.Contains(s.KhatianDetailId)).ToList();
            _dbContext.KhatianDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveOwnerDetailInfo(List<Guid> odIds, Guid landMasterId)
        {
            var removeData = _dbContext.LandOwnersDetails.Where(s => s.LandMasterId == landMasterId && !odIds.Contains(s.LandOwnersDetailId)).ToList();
            _dbContext.LandOwnersDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        public void RemoveBayaDeedDetailInfo(List<Guid> bddIds, Guid landMasterId)
        {
            var removeData = _dbContext.BayaDeedDetails.Where(s => s.LandMasterId == landMasterId && !bddIds.Contains(s.BayaDeedDetailId)).ToList();
            _dbContext.BayaDeedDetails.RemoveRange(removeData);
            _dbContext.SaveChanges();
        }
        #endregion

        public async Task<GridEntity<GetAllLandMasterGridVm>> GetAllMasterGridAsync(GridOptions options)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters
                            where lm.IsDeleted == false
                            
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into cmnDistricts
                            from d in cmnDistricts.DefaultIfEmpty()
                            
                            join dv in _dbContext.CmnDivisions on lm.DivisionId equals dv.DivisionId into cmnDivisions
                            from dv in cmnDivisions.DefaultIfEmpty()
                            
                            join up in _dbContext.CmnUpozilas on lm.UpozilaId equals up.UpozilaId into cmnUpozilas
                            from up in cmnUpozilas.DefaultIfEmpty()
                            
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into lodowner
                            from lod in lodowner.DefaultIfEmpty()
                            
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into cmnMouzas
                            from m in cmnMouzas.DefaultIfEmpty()
                            
                            join o in _dbContext.OwnerInfos on lod.OwnerInfoId equals o.OwnerInfoId into owner
                            from o in owner.DefaultIfEmpty()

                            join sro in _dbContext.CmnSubRegOffices on lm.SubRegOfficeId equals sro.SubRegOfficeId into cmnSubRegOffices
                            from sro in cmnSubRegOffices.DefaultIfEmpty()

                            join fld in _dbContext.FileLocationDetails on lm.LandMasterId equals fld.LandMasterId into fileLocationDetail
                            from fld in fileLocationDetail.DefaultIfEmpty()

                            join flm in _dbContext.FileLocationMasters on fld.FileLocationMasterId equals flm.FileLocationMasterId into fileLocationmaster
                            from flm in fileLocationmaster.DefaultIfEmpty()

                            join fci in _dbContext.FileCodeInfos on flm.FileCodeInfoId equals fci.FileCodeInfoId into fileCodeInfos
                            from fci in fileCodeInfos.DefaultIfEmpty()

                            join fni in _dbContext.FileNoInfos on flm.FileNoInfoId equals fni.FileNoInfoId into fileNoInfos
                            from fni in fileNoInfos.DefaultIfEmpty()

                            group new
                            {
                                lm.LandMasterId,
                                flm.FileCodeInfoId,
                                fci.FileCodeInfoName,
                                flm.RackNoInfoId,
                                fni.FileNoInfoName,
                                lm.DivisionId,
                                dv.DivisionName,
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                up.UpozilaName,
                                //lod.MouzaId,
                                m.MouzaName,
                                //lod.OwnerInfoId,
                                o.OwnerInfoName,
                                lm.EntryDate,
                                lm.DeedNo,
                                lm.SubRegOfficeId,
                                sro.SubRegOfficeName,
                                lm.IsBayna,
                                lm.IsTransfered,
                                lm.IsSale,
                                lm.TotalLandAmount,
                                lm.LandRegAmount,
                                lm.LandPurchaseAmount,
                                lm.LandDevelopmentAmount,
                                lm.LandOtherAmount,
                                lm.Remarks,
                                lm.FileRemarks,
                                lm.CreatedAt,
                                lm.IsDeleted
                            }

                                by new
                                {
                                    lm.LandMasterId,
                                    flm.FileCodeInfoId,
                                    fci.FileCodeInfoName,
                                    flm.RackNoInfoId,
                                    fni.FileNoInfoName,
                                    lm.DivisionId,
                                    dv.DivisionName,
                                    lm.DistrictId,
                                    d.DistrictName,
                                    lm.UpozilaId,
                                    up.UpozilaName,
                                    //lod.MouzaId,
                                    //m.MouzaName,
                                    //lod.OwnerInfoId,
                                    //o.OwnerInfoName,
                                    lm.EntryDate,
                                    lm.DeedNo,
                                    lm.SubRegOfficeId,
                                    sro.SubRegOfficeName,
                                    lm.IsBayna,
                                    lm.IsTransfered,
                                    lm.IsSale,
                                    lm.TotalLandAmount,
                                    lm.LandRegAmount,
                                    lm.LandPurchaseAmount,
                                    lm.LandDevelopmentAmount,
                                    lm.LandOtherAmount,
                                    lm.Remarks,
                                    lm.FileRemarks,
                                    lm.CreatedAt,
                                    lm.IsDeleted
                                } into g
                            select new GetAllLandMasterGridVm
                            {
                                LandMasterId = g.Key.LandMasterId,
                                FileNo = g.Key.FileCodeInfoName + " - " + g.Key.FileNoInfoName,
                                DivisionId = g.Key.DivisionId,
                                DivisionName = g.Key.DivisionName,
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                //MouzaId = g.Key.MouzaId,
                                MouzaName = string.Join(", ", g.Select(i => i.MouzaName)),
                                //OwnerInfoId = g.Key.OwnerInfoId,
                                OwnerInfoName = string.Join(", ", g.Select(i => i.OwnerInfoName)),
                                EntryDate = g.Key.EntryDate,
                                DeedNo = g.Key.DeedNo,
                                SubRegOfficeId = g.Key.SubRegOfficeId,
                                SubRegOfficeName = g.Key.SubRegOfficeName,
                                IsBayna = g.Key.IsBayna,
                                BaynaStatus = g.Key.IsBayna == true ? "Bayna Deed" : "Not Bayna Deed",
                                IsTransfered = g.Key.IsTransfered,
                                IsSale = g.Key.IsSale,
                                SaleStatus = g.Key.IsSale == true ? "Sale Deed" : "Not Sale Deed",
                                TransferedStatus = g.Key.IsTransfered == true ? "Transfered Deed" : "Not Transfered Deed",
                                TotalLandAmount = g.Key.TotalLandAmount,
                                LandRegAmount = g.Key.LandRegAmount,
                                LandPurchaseAmount = g.Key.LandPurchaseAmount,
                                LandDevelopmentAmount = g.Key.LandDevelopmentAmount,
                                LandOtherAmount = g.Key.LandOtherAmount,
                                Remarks = g.Key.Remarks,
                                FileRemarks = g.Key.FileRemarks,
                                CreatedAt = g.Key.CreatedAt,
                                IsDeleted = g.Key.IsDeleted,
                                FilesVm = _dbContext.CmnDocumentFiles.Where(s => s.ModuleMasterId == g.Key.LandMasterId && s.ModuleName == "Land").AsNoTrackingWithIdentityResolution()
                                                    .Select(f => new FilesVm()
                                                    {
                                                        name = f.FileName,
                                                        size = (int)f.FileSize,
                                                        extension = f.FileExtension,
                                                        docId = f.DocumentId,
                                                        fileUniq = f.FileUniqueName
                                                    }).ToList()
                            }).OrderByDescending(o => o.CreatedAt).ToList().AsQueryable();
                var res = KendoGrid<GetAllLandMasterGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<List<PlotWiseLandSaleDetailByLandMasterIdVm>> GetAllPlotWiseLandSaleDetailByLandMasterId(Guid landMasterId)
        {
            var saleDeedNo = (from lm in _dbContext.LandMasters
                              join lsd in _dbContext.PlotWiseLandSaleDetails on lm.LandMasterId equals lsd.SaleLandMasterId into saleDeed
                              from lsd in saleDeed.DefaultIfEmpty()
                              where (lsd.LandMasterId == landMasterId)
                              select new
                              {
                                  lm.DeedNo
                              }).FirstOrDefault();


            var list = await (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                              join lsd in _dbContext.PlotWiseLandSaleDetails on lm.LandMasterId equals lsd.LandMasterId into landDetails
                              from lsd in landDetails.DefaultIfEmpty()
                              join kt in _dbContext.KhatianTypes on lsd.SaleKhatianTypeId equals kt.KhatianTypeId into khatianTypes
                              from kt in khatianTypes.DefaultIfEmpty()
                              where (lsd.LandMasterId == landMasterId)
                              select new PlotWiseLandSaleDetailByLandMasterIdVm
                              {
                                  PlotWiseLandSaleDetailId = lsd.PlotWiseLandSaleDetailId,
                                  LandMasterId = lsd.LandMasterId,
                                  SaleLandMasterId = lsd.SaleLandMasterId,
                                  SaleDeedNo = saleDeedNo.DeedNo,
                                  SaleKhatianTypeId = lsd.SaleKhatianTypeId,
                                  SaleKhatianTypeName = kt.KhatianTypeName,
                                  SaleDagNo = lsd.SaleDagNo,
                                  PlotWiseSaleLandAmount = lsd.PlotWiseSaleLandAmount
                              }).ToListAsync();
            return list;

        }

        public async Task<List<OwnerWiseLandSaleDetailByLandMasterIdVm>> GetAllOwnerWiseLandSaleDetailByLandMasterId(Guid landMasterId)
        {
            var saleDeedNo = (from lm in _dbContext.LandMasters
                              join lsd in _dbContext.OwnerWiseLandSaleDetails on lm.LandMasterId equals lsd.SaleLandMasterId into saleDeed
                              from lsd in saleDeed.DefaultIfEmpty()
                              where (lsd.LandMasterId == landMasterId)
                              select new
                              {
                                  lm.DeedNo
                              }).FirstOrDefault();

            var list = await (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                              join lsd in _dbContext.OwnerWiseLandSaleDetails on lm.LandMasterId equals lsd.LandMasterId into landDetails
                              from lsd in landDetails.DefaultIfEmpty()
                              join kt in _dbContext.KhatianTypes on lsd.SaleKhatianTypeId equals kt.KhatianTypeId into khatianTypes
                              from kt in khatianTypes.DefaultIfEmpty()
                              join oi in _dbContext.OwnerInfos on lsd.SaleOwnerInfoId equals oi.OwnerInfoId into owners
                              from oi in owners.DefaultIfEmpty()
                              where (lsd.LandMasterId == landMasterId)
                              select new OwnerWiseLandSaleDetailByLandMasterIdVm
                              {
                                  OwnerWiseLandSaleDetailId = lsd.OwnerWiseLandSaleDetailId,
                                  LandMasterId = lsd.LandMasterId,
                                  SaleLandMasterId = lsd.SaleLandMasterId,
                                  SaleDeedNo = saleDeedNo.DeedNo,
                                  SaleKhatianTypeId = lsd.SaleKhatianTypeId,
                                  SaleKhatianTypeName = kt.KhatianTypeName,
                                  SaleOwnerInfoId = lsd.SaleOwnerInfoId,
                                  SaleOwnerInfoName = oi.OwnerInfoName,
                                  OwnerWiseSaleLandAmount = lsd.OwnerWiseSaleLandAmount
                              }).ToListAsync();
            return list;

        }
        public async Task<List<PlotWiseLandTransferDetailByLandMasterIdVm>> GetAllPlotWiseLandTransferDetailByLandMasterId(Guid landMasterId)
        {
            var saleDeedNo = (from lm in _dbContext.LandMasters
                              join lsd in _dbContext.PlotWiseLandTransferDetails on lm.LandMasterId equals lsd.TransferedLandMasterId into saleDeed
                              from lsd in saleDeed.DefaultIfEmpty()
                              where (lsd.LandMasterId == landMasterId)
                              select new
                              {
                                  lm.DeedNo
                              }).FirstOrDefault();

            var list = await (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                              join ltd in _dbContext.PlotWiseLandTransferDetails on lm.LandMasterId equals ltd.LandMasterId into landTransferDetails
                              from ltd in landTransferDetails.DefaultIfEmpty()
                              join kt in _dbContext.KhatianTypes on ltd.TransferedKhatianTypeId equals kt.KhatianTypeId into khatianTypes
                              from kt in khatianTypes.DefaultIfEmpty()
                              where (ltd.LandMasterId == landMasterId)
                              select new PlotWiseLandTransferDetailByLandMasterIdVm
                              {
                                  PlotWiseLandTransferDetailId = ltd.PlotWiseLandTransferDetailId,
                                  LandMasterId = ltd.LandMasterId,
                                  TransferedLandMasterId = ltd.TransferedLandMasterId,
                                  TransferedDeedNo = saleDeedNo.DeedNo,
                                  TransferedKhatianTypeId = ltd.TransferedKhatianTypeId,
                                  TransferedKhatianTypeName = kt.KhatianTypeName,
                                  TransferedDagNo = ltd.TransferedDagNo,
                                  PlotWiseTransferedLandAmount = ltd.PlotWiseTransferedLandAmount
                              }).ToListAsync();
            return list;

        }
        public async Task<List<OwnerWiseLandTransferDetailByLandMasterIdVm>> GetAllOwnerWiseLandTransferDetailByLandMasterId(Guid landMasterId)
        {
            try
            {
                var saleDeedNo = (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                                  join lsd in _dbContext.OwnerWiseLandTransferDetails on lm.LandMasterId equals lsd.TransferedLandMasterId into saleDeed
                                  from lsd in saleDeed.DefaultIfEmpty()
                                  where (lsd.LandMasterId == landMasterId)
                                  select new
                                  {
                                      lm.DeedNo
                                  }).FirstOrDefault();
                var list = new List<OwnerWiseLandTransferDetailByLandMasterIdVm>();
                if (saleDeedNo != null)
                {
                    list = await (from lm in _dbContext.LandMasters
                                  join ltd in _dbContext.OwnerWiseLandTransferDetails on lm.LandMasterId equals ltd.LandMasterId into landTransferDetails
                                  from ltd in landTransferDetails.DefaultIfEmpty()
                                  join kt in _dbContext.KhatianTypes on ltd.TransferedKhatianTypeId equals kt.KhatianTypeId into khatianTypes
                                  from kt in khatianTypes.DefaultIfEmpty()
                                  join oi in _dbContext.OwnerInfos on ltd.TransferedOwnerInfoId equals oi.OwnerInfoId into ownerInfos
                                  from oi in ownerInfos.DefaultIfEmpty()
                                  where (ltd.LandMasterId == landMasterId)
                                  select new OwnerWiseLandTransferDetailByLandMasterIdVm
                                  {
                                      OwnerWiseLandTransferDetailId = ltd.OwnerWiseLandTransferDetailId,
                                      LandMasterId = ltd.LandMasterId,
                                      TransferedLandMasterId = ltd.TransferedLandMasterId,
                                      TransferedDeedNo = saleDeedNo.DeedNo ?? "",
                                      TransferedKhatianTypeId = ltd.TransferedKhatianTypeId,
                                      TransferedKhatianTypeName = kt.KhatianTypeName,
                                      TransferedOwnerInfoId = ltd.TransferedOwnerInfoId,
                                      TransferedOwnerInfoName = oi.OwnerInfoName,
                                      OwnerWiseTransferedLandAmount = ltd.OwnerWiseTransferedLandAmount
                                  }).ToListAsync();
                }


                return list;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<LandSalerInfoListByLandMasterIdVm>> GetAllLandSalerInfoListByLandMasterId(Guid landMasterId)
        {
            var list = await (from lm in _dbContext.LandMasters.Where(f=> f.IsDeleted == false)
                              join lsi in _dbContext.LandSalersInfos on lm.LandMasterId equals lsi.LandMasterId into landSalerInfo
                              from lsi in landSalerInfo.DefaultIfEmpty()
                              where (lm.LandMasterId == landMasterId)
                              select new LandSalerInfoListByLandMasterIdVm
                              {
                                  SalersInfoId = lsi.SalersInfoId,
                                  LandMasterId = lm.LandMasterId,
                                  SalerName = lsi.SalerName,
                                  SalerFatherName = lsi.SalerFatherName,
                                  SalerAddress = lsi.SalerAddress
                              }).ToListAsync();
            return list;
        }
        #region Khatian Detail List
        public async Task<List<KhatianDetailListByLandMasterIdVm>> GetAllKhatianDetailListByLandMasterId(Guid landMasterId)
        {
            try
            {
                var data = await _dbContext.KhatianDetails.Where(x => x.LandMasterId == landMasterId).AsNoTracking()
                    .Include(j => j.Mouza)
                    .Include(k => k.KhatianType)
                    .Select(s => new KhatianDetailListByLandMasterIdVm
                    {
                        KhatianDetailId = s.KhatianDetailId,
                        LandMasterId = s.LandMasterId,
                        MouzaId = s.MouzaId,
                        MouzaName = s.Mouza.MouzaName,
                        KhatianTypeId = s.KhatianTypeId,
                        KhatianTypeName = s.KhatianType.KhatianTypeName,
                        KhatianNo = s.KhatianNo,
                        DagNo = s.DagNo,
                        RecordedOwnerName = s.RecordedOwnerName
                    }).OrderBy(o => o.MouzaName).ThenBy(tb => tb.KhatianTypeName).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        #endregion
        public async Task<List<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>> GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId(Guid landMasterId, Guid mouzaId, Guid khatianTypeId)
        {
            try
            {
                var data = await _dbContext.KhatianDetails
                    .Where(x => x.LandMasterId == landMasterId && x.MouzaId == mouzaId
                                && x.KhatianTypeId == khatianTypeId).AsNoTracking()
                    .Include(j => j.Mouza)
                    .Include(k => k.KhatianType)
                    .Select(s => new KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm
                    {
                        KhatianDetailId = s.KhatianDetailId,
                        LandMasterId = s.LandMasterId,
                        MouzaId = s.MouzaId,
                        MouzaName = s.Mouza.MouzaName,
                        KhatianTypeId = s.KhatianTypeId,
                        KhatianTypeName = s.KhatianType.KhatianTypeName,
                        KhatianNo = s.KhatianNo,
                        DagNo = s.DagNo,
                        RecordedOwnerName = s.RecordedOwnerName
                    }).OrderBy(o => o.KhatianTypeName).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<List<KhatianTypeListByLandMasterIdMouzaIdVm>> GetAllKhatianTypeListByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId)
        {
            try
            {
                var data = await _dbContext.KhatianDetails
                    .Where(x => x.LandMasterId == landMasterId && x.MouzaId == mouzaId).AsNoTracking()
                    .Include(k => k.KhatianType)
                    .Select(s => new KhatianTypeListByLandMasterIdMouzaIdVm
                    {
                        KhatianDetailId = s.KhatianDetailId,
                        KhatianTypeId = s.KhatianTypeId,
                        KhatianTypeName = s.KhatianType.KhatianTypeName,
                    }).OrderBy(o => o.KhatianTypeName).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<List<KhatianTypeListByLandMasterIdVm>> GetAllKhatianTypeListByLandMasterId(Guid landMasterId)
        {
            try
            {
                var query = (from pwm in _dbContext.PlotWiseMutationDetails
                             join kt in _dbContext.KhatianTypes on pwm.KhatianTypeId equals kt.KhatianTypeId into khatianType
                             from kt in khatianType.DefaultIfEmpty()
                             where (pwm.LandMasterId == landMasterId)
                             group new { pwm.LandMasterId, pwm.KhatianTypeId, kt.KhatianTypeName }
                             by new { pwm.LandMasterId, pwm.KhatianTypeId, kt.KhatianTypeName } into g
                             select new KhatianTypeListByLandMasterIdVm
                             {
                                 LandMasterId = g.Key.LandMasterId,
                                 KhatianTypeId = g.Key.KhatianTypeId,
                                 KhatianTypeName = g.Key.KhatianTypeName
                             }).OrderBy(o => o.KhatianTypeName).AsNoTracking().ToList();
                return await Task.FromResult(query);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        #region Land Owner Detail List
        public async Task<List<LandOwnerListByLandMasterIdVm>> GetAllLandOwnerListByLandMasterId(Guid landMasterId)
        {
            try
            {
                var data = await _dbContext.LandOwnersDetails.Where(x => x.LandMasterId == landMasterId).AsNoTracking()
                    .Include(i => i.OwnerInfo)
                    .Include(j => j.Mouza)
                    .Include(k => k.LandMaster)
                    .Select(s => new LandOwnerListByLandMasterIdVm
                    {
                        LandOwnersDetailId = s.LandOwnersDetailId,
                        LandMasterId = s.LandMasterId,
                        OwnerInfoId = s.OwnerInfoId,
                        OwnerInfoName = s.OwnerInfo.OwnerInfoName,
                        SaleOwnerName = s.SaleOwnerName,
                        MouzaId = s.MouzaId,
                        MouzaName = s.Mouza.MouzaName,
                        LandAmount = s.LandAmount,
                        OwnerRegAmount = s.OwnerRegAmount,
                        OwnerPurchaseAmount = s.OwnerPurchaseAmount
                    }).OrderBy(o => o.MouzaName).ThenBy(tb => tb.OwnerInfoName).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<List<BayaDeedDetailListByLandMasterIdVm>> GetAllBayaDeedDetailListByLandMasterId(Guid landMasterId)
        {
            try
            {
                var data = await _dbContext.BayaDeedDetails.Where(x => x.LandMasterId == landMasterId).AsNoTracking()
                                    .Select(s => new BayaDeedDetailListByLandMasterIdVm
                                    {
                                        BayaDeedDetailId = s.BayaDeedDetailId,
                                        LandMasterId = s.LandMasterId,
                                        BayaDeedNo = s.BayaDeedNo,
                                        BayaDeedDate = s.BayaDeedDate
                                    }).OrderBy(o => o.BayaDeedNo).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        #endregion
        public async Task<List<DeedNoListByMouzaIdVm>> GetDeedNoListByMouzaId(Guid mouzaId)
        {
            try
            {
                var data = await (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                                  join kd in _dbContext.KhatianDetails on lm.LandMasterId equals kd.LandMasterId into khatianDetail
                                  from kd in khatianDetail.DefaultIfEmpty()
                                  where (kd.MouzaId == mouzaId && lm.IsBayna == false)
                                  group new { lm.LandMasterId, lm.DeedNo }
                                  by new { lm.LandMasterId, lm.DeedNo } into g
                                  select new DeedNoListByMouzaIdVm
                                  {
                                      LandMasterId = g.Key.LandMasterId,
                                      DeedNo = g.Key.DeedNo
                                  }).OrderBy(o => o.DeedNo).AsNoTracking().ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<List<AllDeedNoListVm>> GetAllDeedNoList()
        {
            try
            {
                var data = await _dbContext.LandMasters.Where(f => f.IsDeleted == false).AsNoTracking()
                    .Include(i => i.SubRegOffice)
                    .Select(s => new AllDeedNoListVm
                    {
                        LandMasterId = s.LandMasterId,
                        DeedNo = s.DeedNo,
                        EntryDate = s.EntryDate,
                        SubRegOfficeId = s.SubRegOfficeId,
                        SubRegOfficeName = s.SubRegOffice.SubRegOfficeName,
                        TotalLandAmount = s.TotalLandAmount
                    }).OrderBy(o => o.DeedNo).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<decimal> GetLandAmountByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId)
        {
            try
            {
                var totalLandAmount = _dbContext.LandOwnersDetails
                    .Include(i => i.LandMaster)
                    .Where(x => x.LandMasterId == landMasterId && x.MouzaId == mouzaId).Sum(x => x.LandAmount);
                //decimal result = totalLandAmount.HasValue ? totalLandAmount.Value : 0;
                return (decimal)totalLandAmount;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #region Dashboard Master Report
        public async Task<decimal> GetTotalLandAmount()
        {
            try
            {
                var landAmountDecimal = _dbContext.LandMasters.AsNoTracking().Where(w => w.IsBayna == false && w.IsDeleted == false).Sum(x => x.TotalLandAmount);
                var landAmountAcres = landAmountDecimal / 100;
                return landAmountAcres;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<decimal> GetTotalLandPurchaseAmount()
        {
            try
            {
                var landPurchaseAmount = _dbContext.LandMasters.AsNoTracking().Where(w => w.IsBayna == false && w.IsDeleted == false).Sum(x => x.LandPurchaseAmount);
                return landPurchaseAmount;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<int> GetTotalDeed()
        {
            try
            {
                return _dbContext.LandMasters.AsNoTracking().Where(w => w.IsBayna == false && w.IsDeleted == false).Select(s => s.DeedNo).Count();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<int> GetTotalDistrict()
        {
            try
            {
                return _dbContext.LandMasters.AsNoTracking().Where(w => w.IsBayna == false && w.IsDeleted == false).GroupBy(x => x.DistrictId).Count();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<int> GetTotalUpozila()
        {
            try
            {
                return _dbContext.LandMasters.AsNoTracking().Where(w => w.IsBayna == false && w.IsDeleted == false).GroupBy(x => x.UpozilaId).Count();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<int> GetTotalMouza()
        {
            try
            {
                var result = (from lm in _dbContext.LandMasters.Where(f=> f.IsDeleted == false)
                              join kd in _dbContext.KhatianDetails on lm.LandMasterId equals kd.LandMasterId into khatianDetails
                              from kd in khatianDetails.DefaultIfEmpty()
                              where lm.IsBayna == false
                              group kd by kd.MouzaId into g
                              select new
                              {
                                  mouzaId = g.Key
                              }).Count();

                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<GridEntity<GetAllLandSummaryDistrictGridVm>> GetAllLandSummaryDistrictGridAsync(GridOptions options)
        {
            try
            {
                //var data = (from lm in _dbContext.LandMasters
                //            join omd in _dbContext.OwnerWiseMutationDetails on lm.LandMasterId equals omd.LandMasterId
                //            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                //            from d in district.DefaultIfEmpty()
                //            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                //            from u in upozila.DefaultIfEmpty()
                //            where (lm.IsBayna == false && lm.IsDeleted == false)
                //            group new
                //            {
                //                lm.DistrictId,
                //                d.DistrictName,
                //                lm.UpozilaId,
                //                u.UpozilaName,
                //                lm.TotalLandAmount,
                //                lm.DeedNo,
                //                omd.OwnerMutatedLandAmount
                //            }
                //             by new
                //             {
                //                 lm.DistrictId,
                //                 d.DistrictName,
                //                 lm.UpozilaId,
                //                 u.UpozilaName,
                //                 lm.TotalLandAmount,
                //                 lm.DeedNo
                //             } into g
                //            select new GetAllLandSummaryDistrictGridVm
                //            {
                //                DistrictId = g.Key.DistrictId,
                //                DistrictName = g.Key.DistrictName,
                //                DeedQty = g.Count(),
                //                //TotalLandAcres = g.Key.TotalLandAmount,
                //                TotalLandAcres = (decimal)(g.Sum(c => c.TotalLandAmount)) / 100,
                //                OwnerMutatedLandAmount = (decimal)(g.Sum(c => c.OwnerMutatedLandAmount)) / 100
                //            }).ToList();
                //var res = KendoGrid<GetAllLandSummaryDistrictGridVm>.DataSource(options, data.AsQueryable());
                //return await Task.FromResult(res);



                var data = _dbContext.LandMasters.Where(f => f.IsDeleted == false).AsNoTracking()
                    //.Include(h => h.OwnerWiseMutationDetails)
                    .Include(i => i.District)
                    .Include(j => j.Upozila)
                    .Where(w => w.IsBayna == false && w.IsDeleted == false)
                    .GroupBy(g => g.DistrictId).Select(s => new GetAllLandSummaryDistrictGridVm
                    {
                        DistrictId = s.Key,
                        DistrictName = s.FirstOrDefault().District.DistrictName,
                        UpozilaId = s.Key,
                        UpozilaName = s.FirstOrDefault().Upozila.UpozilaName,
                        DeedQty = s.Count(),
                        TotalLandAcres = (s.Sum(c => c.TotalLandAmount)) / 100,
                    }).OrderBy(o => o.DistrictName).ToList().AsQueryable();
                var res = KendoGrid<GetAllLandSummaryDistrictGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<LandSummaryDistrictByDistrictIdVm> GetAllLandSummaryDistrictByDistrictId(Guid districtId)
        {
            try
            {
                var data = _dbContext.LandMasters.Where(f => f.IsDeleted == false).AsNoTracking()
                    .Include(i => i.District)
                    .Where(w => w.IsBayna == false && w.DistrictId == districtId)
                    .GroupBy(g => g.DistrictId).Select(s => new LandSummaryDistrictByDistrictIdVm
                    {
                        DistrictId = s.Key,
                        DistrictName = s.FirstOrDefault().District.DistrictName,
                        DeedQty = s.Count(),
                        TotalLandAcres = (s.Sum(c => c.TotalLandAmount)) / 100
                    }).FirstOrDefault();

                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<GetAllLandSummaryDistrictListVm>> GetAllLandSummaryDistrictList()
        {
            try
            {
                var data = await _dbContext.LandMasters.Where(f => f.IsDeleted == false).AsNoTracking()
                    .Include(i => i.District)
                    .Where(w => w.IsBayna == false)
                    .GroupBy(g => g.DistrictId).Select(s => new GetAllLandSummaryDistrictListVm
                    {
                        DistrictName = s.FirstOrDefault().District.DistrictName,
                        TotalLandAcres = (s.Sum(c => c.TotalLandAmount)) / 100
                    }).OrderBy(o => o.DistrictName).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        #endregion

        #region Dashboard Sub-Master Report
        public async Task<List<GetAllUpozilaByDistrictIdListVm>> GetAllUpozilaByDistrictId(Guid districtId)
        {
            try
            {
                var data = await _dbContext.LandMasters.Where(f => f.IsDeleted == false).AsNoTracking()
                     .Include(i => i.Upozila)
                     .Where(w => w.IsBayna == false && w.DistrictId == districtId)
                     .GroupBy(g => g.UpozilaId).Select(s => new GetAllUpozilaByDistrictIdListVm
                     {
                         UpozilaId = s.Key,
                         UpozilaName = s.FirstOrDefault().Upozila.UpozilaName,
                         DeedQty = s.Count(),
                         TotalLandAcres = (s.Sum(c => c.TotalLandAmount)) / 100
                     }).OrderBy(o => o.UpozilaName).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        #endregion

        #region Report Print
        public async Task<GridEntity<LandSummaryUpozilaGridVm>> GetAllLandSummaryUpozilaGridAsync(GridOptions options)
        {
            //try
            //{
            //    var data = _dbContext.LandMasters.AsNoTracking()
            //        .Include(i => i.District).ThenInclude(th => th.CmnUpozilas)
            //        .Where(w => w.IsBayna == false)
            //        .GroupBy(g => g.UpozilaId).Select(s => new LandSummaryUpozilaGridVm
            //        {
            //            DistrictId = s.FirstOrDefault().DistrictId,
            //            DistrictName = s.FirstOrDefault().District.DistrictName,
            //            UpozilaId = s.Key,
            //            UpozilaName = s.FirstOrDefault().Upozila.UpozilaName,
            //            DeedQty = s.Count(),
            //            TotalLandAcres = (s.Sum(c => c.TotalLandAmount)) / 100
            //        }).OrderBy(o => o.DistrictName).ThenBy(tb => tb.UpozilaName).ToList().AsQueryable();

            //    var res = KendoGrid<LandSummaryUpozilaGridVm>.DataSource(options, data);
            //    return await Task.FromResult(res);
            //}
            //catch (Exception ex)
            //{
            //    throw ex.InnerException;
            //}



            try
            {
                var data = (from lm in _dbContext.LandMasters
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into landms
                            from d in landms.DefaultIfEmpty()
                            join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                            from div in division.DefaultIfEmpty()
                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into lodowner
                            from lod in lodowner.DefaultIfEmpty()
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into cmnMouzas
                            from m in cmnMouzas.DefaultIfEmpty()
                            where (lm.IsBayna == false && lm.IsDeleted == false)
                            group new
                            {
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                m.MouzaId,
                                m.MouzaName,
                                lm.TotalLandAmount
                            }
                            by new
                            {
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                m.MouzaId,
                                m.MouzaName
                            } into g
                            select new LandSummaryUpozilaGridVm
                            {                                
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                MouzaId = g.Key.MouzaId,
                                MouzaName = g.Key.MouzaName,
                                DeedQty = g.Count(),
                                TotalLandAcres = (decimal)g.Sum(c => c.TotalLandAmount) / 100
                            }).ToList();
                var res = KendoGrid<LandSummaryUpozilaGridVm>.DataSource(options, data.AsQueryable());
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<LandSummaryUpazilaByUpazilaIdVm> GetAllLandSummaryUpazilaByUpazilaId(Guid upozilaId)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into cmnDistricts
                            from d in cmnDistricts.DefaultIfEmpty()
                            join up in _dbContext.CmnUpozilas on lm.UpozilaId equals up.UpozilaId into cmnUpozilas
                            from up in cmnUpozilas.DefaultIfEmpty()
                            where (lm.IsBayna == false && lm.UpozilaId == upozilaId)
                            group new { lm.DistrictId, d.DistrictName, lm.UpozilaId, up.UpozilaName, lm.TotalLandAmount }
                            by new { lm.DistrictId, d.DistrictName, lm.UpozilaId, up.UpozilaName } into g
                            select new LandSummaryUpazilaByUpazilaIdVm
                            {
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                DeedQty = g.Count(),
                                TotalLandAcres = (g.Sum(c => c.TotalLandAmount)) / 100
                            }).FirstOrDefault();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GridEntity<LandSummaryMouzaGridVm>> GetAllLandSummaryMouzaGridAsync(GridOptions options)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into landms
                            from d in landms.DefaultIfEmpty()
                            join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                            from div in division.DefaultIfEmpty()
                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into lodowner
                            from lod in lodowner.DefaultIfEmpty()
                            join o in _dbContext.OwnerInfos on lod.OwnerInfoId equals o.OwnerInfoId into owner
                            from o in owner.DefaultIfEmpty()
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into cmnMouzas
                            from m in cmnMouzas.DefaultIfEmpty()
                            where (lm.IsBayna == false)
                            group new
                            {
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                m.MouzaId,
                                m.MouzaName,
                                o.OwnerInfoId,
                                o.OwnerInfoName,
                                lod.LandAmount
                            }
                            by new
                            {
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                m.MouzaId,
                                m.MouzaName,
                                o.OwnerInfoId,
                                o.OwnerInfoName,
                            } into g
                            select new LandSummaryMouzaGridVm
                            {
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                MouzaId = g.Key.MouzaId,
                                MouzaName = g.Key.MouzaName,
                                OwnerInfoId = g.Key.OwnerInfoId,
                                OwnerInfoName = g.Key.OwnerInfoName,
                                DeedQty = g.Count(),
                                TotalLandAmount = (decimal)g.Sum(c => c.LandAmount) / 100
                            }).OrderBy(o=>o.MouzaName).ToList();
                var res = KendoGrid<LandSummaryMouzaGridVm>.DataSource(options, data.AsQueryable());
                return await Task.FromResult(res);











                //var query = (
                //    //from lod in _dbContext.LandOwnersDetails
                ////             join cm in _dbContext.CmnMouzas on lod.MouzaId equals cm.MouzaId into mouzas
                ////             from cm in mouzas.DefaultIfEmpty()

                ////             join lm in _dbContext.LandMasters on lod.LandMasterId equals lm.LandMasterId into landMasters
                ////             from lm in landMasters.DefaultIfEmpty()
                //             from lm in _dbContext.LandMasters
                //             join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                //             from u in upozila.DefaultIfEmpty()
                //             join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into landms
                //             from d in landms.DefaultIfEmpty()
                //             join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                //             from div in division.DefaultIfEmpty()
                //             join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into lodowner
                //             from lod in lodowner.DefaultIfEmpty()
                //             join o in _dbContext.OwnerInfos on lod.OwnerInfoId equals o.OwnerInfoId into owner
                //             from o in owner.DefaultIfEmpty()
                //             join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into cmnMouzas
                //             from m in cmnMouzas.DefaultIfEmpty()

                //                 //join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                //                 //from d in district.DefaultIfEmpty()

                //                 //join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                //                 //from u in upozila.DefaultIfEmpty()

                //                 //join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owner
                //                 //from oi in owner.DefaultIfEmpty()
                //             where (lm.IsBayna == false)
                //             group new
                //             {
                //                 //lm.DistrictId,
                //                 //d.DistrictName,
                //                 //lm.UpozilaId,
                //                 //u.UpozilaName,
                //                 lod.MouzaId,
                //                 m.MouzaName,
                //                 lod.OwnerInfoId,
                //                 o.OwnerInfoName,
                //                 lod.LandAmount
                //             }
                //             by new
                //             {
                //                 //lm.DistrictId,
                //                 //d.DistrictName,
                //                 //lm.UpozilaId,
                //                 //u.UpozilaName,
                //                 lod.MouzaId,
                //                 m.MouzaName,
                //                 lod.OwnerInfoId,
                //                 o.OwnerInfoName,
                //                 lm.DeedNo
                //             } into g
                //             select new LandSummaryMouzaGridVm
                //             {
                //                 //DistrictId = g.Key.DistrictId,
                //                 //DistrictName = g.Key.DistrictName,
                //                 //UpozilaId = g.Key.UpozilaId,
                //                 //UpozilaName = g.Key.UpozilaName,
                //                 MouzaId = g.Key.MouzaId,
                //                 MouzaName = g.Key.MouzaName,
                //                 OwnerInfoId = g.Key.OwnerInfoId,
                //                 OwnerInfoName = g.Key.OwnerInfoName,
                //                 DeedNo = g.Key.DeedNo,
                //                 TotalLand = (g.Sum(c => c.LandAmount))/100

                //             }).ToList().AsQueryable();

                //var data = query != null ?
                //        query.GroupBy(g => new
                //        {
                //            //g.DistrictId,
                //            //g.DistrictName,
                //            //g.UpozilaId,
                //            //g.UpozilaName,
                //            g.MouzaId,
                //            g.MouzaName,
                //            g.OwnerInfoId,
                //            g.OwnerInfoName
                //        }).Select(s => new LandSummaryMouzaGridVm
                //        {
                //            //DistrictId = s.Key.DistrictId,
                //            //DistrictName = s.Key.DistrictName,
                //            //UpozilaId = s.Key.UpozilaId,
                //            //UpozilaName = s.Key.UpozilaName,
                //            MouzaId = s.Key.MouzaId,
                //            MouzaName = s.Key.MouzaName,
                //            OwnerInfoId = s.Key.OwnerInfoId,
                //            OwnerInfoName = s.Key.OwnerInfoName,
                //            DeedQty = s.Count(),
                //            TotalLand = s.Sum(s => s.TotalLand)
                //        }).ToList().AsQueryable().OrderBy(o => o.MouzaName)
                //                : new List<LandSummaryMouzaGridVm>().AsQueryable().OrderBy(o => o.MouzaName);

                //var res = KendoGrid<LandSummaryMouzaGridVm>.DataSource(options, data);
                //return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task<LandSummaryMouzaByMouzaIdVm> GetAllLandSummaryMouzaByMouzaId(Guid mouzaId)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters.Where(f => f.IsDeleted == false)
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into cmnDistricts
                            from d in cmnDistricts.DefaultIfEmpty()
                            join up in _dbContext.CmnUpozilas on lm.UpozilaId equals up.UpozilaId into cmnUpozilas
                            from up in cmnUpozilas.DefaultIfEmpty()
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into ownerDetail
                            from lod in ownerDetail.DefaultIfEmpty()
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into mouza
                            from m in mouza.DefaultIfEmpty()

                            where (lm.IsBayna == false && lod.MouzaId == mouzaId)
                            group new { lm.DistrictId, d.DistrictName, lm.UpozilaId, up.UpozilaName, lod.MouzaId, m.MouzaName, lod.LandAmount }
                            by new { lm.DistrictId, d.DistrictName, lm.UpozilaId, up.UpozilaName, lod.MouzaId, m.MouzaName } into g
                            select new LandSummaryMouzaByMouzaIdVm
                            {
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                MouzaId = g.Key.MouzaId,
                                MouzaName = g.Key.MouzaName,
                                DeedQty = g.Count(),
                                TotalLand = g.Sum(c => c.LandAmount)
                            }).FirstOrDefault();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GridEntity<GetAllLandSummaryOwnerMouzaCommonGridVm>> GetAllLandSummaryOwnerMouzaCommonGrid(GridOptions options)
        {
            try
            {
                var data = (from lod in _dbContext.LandOwnersDetails
                            join cm in _dbContext.CmnMouzas on lod.MouzaId equals cm.MouzaId into mouzas
                            from cm in mouzas.DefaultIfEmpty()

                            join lm in _dbContext.LandMasters on lod.LandMasterId equals lm.LandMasterId into landMasters
                            from lm in landMasters.DefaultIfEmpty()

                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                            from d in district.DefaultIfEmpty()

                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()

                            join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owner
                            from oi in owner.DefaultIfEmpty()
                            where (lm.IsBayna == false && lm.IsDeleted == false)
                            group new
                            {
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                lod.MouzaId,
                                cm.MouzaName,
                                lod.OwnerInfoId,
                                oi.OwnerInfoName,
                                lod.LandAmount
                            }
                            by new
                            {
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                lod.MouzaId,
                                cm.MouzaName,
                                lod.OwnerInfoId,
                                oi.OwnerInfoName,
                            } into g
                            select new GetAllLandSummaryOwnerMouzaCommonGridVm
                            {
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                MouzaId = g.Key.MouzaId,
                                MouzaName = g.Key.MouzaName,
                                OwnerInfoId = g.Key.OwnerInfoId,
                                OwnerInfoName = g.Key.OwnerInfoName,
                                DeedQty = g.Count(),
                                TotalLand = g.Sum(c => c.LandAmount)/100
                            }).ToList().AsQueryable().OrderBy(o => o.OwnerInfoName);

                var res = KendoGrid<GetAllLandSummaryOwnerMouzaCommonGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GridEntity<GetAllLandSummaryFileDeedOwnerCommonGridVm>> GetAllLandSummaryFileDeedOwnerCommonGrid(GridOptions options)
        {
            try
            {
                var data = (from flm in _dbContext.FileLocationMasters
                            join fc in _dbContext.FileCodeInfos on flm.FileCodeInfoId equals fc.FileCodeInfoId into fileCodeInfos
                            from fc in fileCodeInfos.DefaultIfEmpty()

                            join fn in _dbContext.FileNoInfos on flm.FileNoInfoId equals fn.FileNoInfoId into fileNoInfos
                            from fn in fileNoInfos.DefaultIfEmpty()

                            join fld in _dbContext.FileLocationDetails on flm.FileLocationMasterId equals fld.FileLocationMasterId into fileLocationDetails
                            from fld in fileLocationDetails.DefaultIfEmpty()

                            join lm in _dbContext.LandMasters on fld.LandMasterId equals lm.LandMasterId into landMaster
                            from lm in landMaster.DefaultIfEmpty()

                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into cmnDistricts
                            from d in cmnDistricts.DefaultIfEmpty()

                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()

                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                            from lod in landOwnerDetails.DefaultIfEmpty()


                            join cm in _dbContext.CmnMouzas on lod.MouzaId equals cm.MouzaId into mouzas
                            from cm in mouzas.DefaultIfEmpty()

                            join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owner
                            from oi in owner.DefaultIfEmpty()

                            where (lm.IsBayna == false && lm.IsDeleted == false)

                            select new GetAllLandSummaryFileDeedOwnerCommonGridVm
                            {
                                FileCodeInfoId = flm.FileCodeInfoId,
                                FileCodeInfoName = fc.FileCodeInfoName,
                                FileNoInfoId = flm.FileNoInfoId,
                                FileNoInfoName = fn.FileNoInfoName,
                                DistrictId = lm.DistrictId,
                                DistrictName = d.DistrictName,
                                UpozilaId = lm.UpozilaId,
                                UpozilaName = u.UpozilaName,
                                MouzaId = lod.MouzaId,
                                MouzaName = cm.MouzaName,
                                OwnerInfoId = lod.OwnerInfoId,
                                OwnerInfoName = oi.OwnerInfoName,
                                DeedNo = lm.DeedNo,
                                LandAmount = lod.LandAmount
                            }).ToList().OrderBy(o => o.DistrictName).ThenBy(t => t.UpozilaName).ThenBy(t => t.MouzaName).ThenBy(t => t.OwnerInfoName).AsQueryable();

                var res = KendoGrid<GetAllLandSummaryFileDeedOwnerCommonGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<List<DeedNoByOwnerInfoIdVm>> GetAllDeedNoByOwnerInfoId(Guid ownerInfoId)
        {
            try
            {
                var data = await (from lm in _dbContext.LandMasters
                                  join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landOwnerDetails
                                  from lod in landOwnerDetails.DefaultIfEmpty()
                                  join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owners
                                  from oi in owners.DefaultIfEmpty()

                                  where (lm.IsBayna == false && lm.IsDeleted == false && lod.OwnerInfoId == ownerInfoId)
                                  group new { lm.LandMasterId, lm.DeedNo }
                                  by new { lm.LandMasterId, lm.DeedNo } into g
                                  select new DeedNoByOwnerInfoIdVm
                                  {
                                      LandMasterId = g.Key.LandMasterId,
                                      DeedNo = g.Key.DeedNo
                                  }).OrderBy(o => o.DeedNo).AsNoTracking().ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<GridEntity<LandSummaryUpozilaByDistrictIdGridVm>> GetAllLandSummaryUpozilaByDistrictIdGridAsync(GridOptions options, Guid districtId)
        {
            try
            {
                var data = _dbContext.LandMasters.Where(f => f.IsDeleted == false).AsNoTracking()
                    .Include(i => i.District).ThenInclude(th => th.CmnUpozilas)
                    .Where(w => w.IsBayna == false && w.DistrictId == districtId)
                    .GroupBy(g => g.UpozilaId).Select(s => new LandSummaryUpozilaByDistrictIdGridVm
                    {
                        DistrictId = s.FirstOrDefault().DistrictId,
                        DistrictName = s.FirstOrDefault().District.DistrictName,
                        UpozilaId = s.Key,
                        UpozilaName = s.FirstOrDefault().Upozila.UpozilaName,
                        DeedQty = s.Count(),
                        TotalLandAcres = (s.Sum(c => c.TotalLandAmount)) / 100
                    }).OrderBy(o => o.DistrictName).ThenBy(tb => tb.UpozilaName).ToList().AsQueryable();

                var res = KendoGrid<LandSummaryUpozilaByDistrictIdGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GridEntity<LandSummaryMouzaByUpozilaIdGridVm>> GetAllLandSummaryMouzaByUpozilaIdGridAsync(GridOptions options, Guid upozilaId)
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
                             where (lm.IsBayna == false && lm.IsDeleted == false && lm.UpozilaId == upozilaId)
                             group new
                             {
                                 lm.DistrictId,
                                 d.DistrictName,
                                 lm.UpozilaId,
                                 u.UpozilaName,
                                 //lm.DeedNo,
                                 lod.MouzaId,
                                 cm.MouzaName,
                                 lod.LandAmount
                             }
                             by new
                             {
                                 lm.DistrictId,
                                 d.DistrictName,
                                 lm.UpozilaId,
                                 u.UpozilaName,
                                 //lm.DeedNo,
                                 lod.MouzaId,
                                 cm.MouzaName,
                             } into g
                             select new LandSummaryMouzaByUpozilaIdGridVm
                             {
                                 DistrictId = g.Key.DistrictId,
                                 DistrictName = g.Key.DistrictName,
                                 UpozilaId = g.Key.UpozilaId,
                                 UpozilaName = g.Key.UpozilaName,
                                 MouzaId = g.Key.MouzaId,
                                 MouzaName = g.Key.MouzaName,
                                 //DeedNo = g.Key.DeedNo,
                                 //DeedQty = g.Count(),
                                 TotalLand = g.Sum(c => c.LandAmount)

                             }).ToList().AsQueryable();

                var data = query != null ?
                        query.GroupBy(g => new
                        {
                            g.DistrictId,
                            g.DistrictName,
                            g.UpozilaId,
                            g.UpozilaName,
                            g.MouzaId,
                            g.MouzaName
                        }).Select(s => new LandSummaryMouzaByUpozilaIdGridVm
                        {
                            DistrictId = s.Key.DistrictId,
                            DistrictName = s.Key.DistrictName,
                            UpozilaId = s.Key.UpozilaId,
                            UpozilaName = s.Key.UpozilaName,
                            MouzaId = s.Key.MouzaId,
                            MouzaName = s.Key.MouzaName,
                            DeedQty = s.Count(),
                            TotalLand = s.Sum(s => s.TotalLand)
                        }).ToList().AsQueryable().OrderBy(o => o.MouzaName) : new List<LandSummaryMouzaByUpozilaIdGridVm>().AsQueryable().OrderBy(o => o.MouzaName);

                var res = KendoGrid<LandSummaryMouzaByUpozilaIdGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        #endregion
        public async Task<decimal> GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo(Guid transferedLandMasterId, Guid transferedKhatianTypeId, int transferedDagNo)
        {
            try
            {

                var totalPlotWiseTransferedLandDecimal = _dbContext.PlotWiseLandTransferDetails
                                                        .Where(w => w.TransferedLandMasterId == transferedLandMasterId
                                                                    && w.TransferedKhatianTypeId == transferedKhatianTypeId
                                                                    && w.TransferedDagNo == transferedDagNo)
                                              .AsNoTracking().Sum(x => x.PlotWiseTransferedLandAmount);
                return totalPlotWiseTransferedLandDecimal;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<decimal> GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid transferedLandMasterId, Guid transferedKhatianTypeId, Guid transferedOwnerInfoId)
        {
            try
            {

                var totalOwnerWiseTransferedLandDecimal = _dbContext.OwnerWiseLandTransferDetails
                                                        .Where(w => w.TransferedLandMasterId == transferedLandMasterId
                                                                    && w.TransferedKhatianTypeId == transferedKhatianTypeId
                                                                    && w.TransferedOwnerInfoId == transferedOwnerInfoId)
                                              .AsNoTracking().Sum(x => x.OwnerWiseTransferedLandAmount);
                return totalOwnerWiseTransferedLandDecimal;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<decimal> GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo(Guid saleLandMasterId, Guid saleKhatianTypeId, int saleDagNo)
        {
            try
            {

                var totalPlotWiseSaleLandDecimal = _dbContext.PlotWiseLandSaleDetails
                                                        .Where(w => w.SaleLandMasterId == saleLandMasterId
                                                                    && w.SaleKhatianTypeId == saleKhatianTypeId
                                                                    && w.SaleDagNo == saleDagNo)
                                              .AsNoTracking().Sum(x => x.PlotWiseSaleLandAmount);
                return totalPlotWiseSaleLandDecimal;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<decimal> GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid saleLandMasterId, Guid saleKhatianTypeId, Guid saleOwnerInfoId)
        {
            try
            {

                var totalOwnerWiseSaleLandDecimal = _dbContext.OwnerWiseLandSaleDetails
                                                        .Where(w => w.SaleLandMasterId == saleLandMasterId
                                                                    && w.SaleKhatianTypeId == saleKhatianTypeId
                                                                    && w.SaleOwnerInfoId == saleOwnerInfoId)
                                              .AsNoTracking().Sum(x => x.OwnerWiseSaleLandAmount);
                return totalOwnerWiseSaleLandDecimal;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        //public async Task<GridEntity<GetAllLandSummaryByIdVm>> GetLandSummaryById(GridOptions options, Guid? DivisionId, Guid? DistrictId, Guid? UpozilaId, Guid? MouzaId, Guid? OwnerInfoId)
        //{
        //    try
        //    {

        //        var data = (from lm in _dbContext.LandMasters
        //                    join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
        //                    from div in division.DefaultIfEmpty()

        //                    join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
        //                    from d in district.DefaultIfEmpty()

        //                    join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
        //                    from u in upozila.DefaultIfEmpty()

        //                    join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into landowner
        //                    from lod in landowner.DefaultIfEmpty()

        //                    join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId

        //                    join cm in _dbContext.CmnMouzas on lod.MouzaId equals cm.MouzaId
        //                    join cm1 in _dbContext.CmnMouzas on u.UpozilaId equals cm1.UpozilaId

                            
        //                    where (lm.IsBayna == false)

        //                    group new
        //                    {
        //                        lm.DivisionId,
        //                        div.DivisionName,
        //                        lm.DistrictId,
        //                        d.DistrictName,
        //                        u.UpozilaName,
        //                        cm.MouzaName,
        //                        oi.OwnerInfoName,
        //                        lod.LandAmount
        //                    }
        //                    by new
        //                    {
        //                        lm.DivisionId,
        //                        div.DivisionName,
        //                        lm.DistrictId,
        //                        d.DistrictName,
        //                        lm.UpozilaId,
        //                        u.UpozilaName,
        //                        lod.MouzaId,
        //                        cm.MouzaName,
        //                        oi.OwnerInfoId,
        //                        oi.OwnerInfoName,
        //                    } into g
        //                    select new GetAllLandSummaryByIdVm
        //                    {
        //                        DivisionId = g.Key.DivisionId,
        //                        DivisionName = g.Key.DivisionName,
        //                        DistrictId = g.Key.DistrictId,
        //                        DistrictName = g.Key.DistrictName,
        //                        UpozilaId = g.Key.UpozilaId,
        //                        UpozilaName = g.Key.UpozilaName,
        //                        MouzaId = g.Key.MouzaId,
        //                        MouzaName = g.Key.MouzaName,
        //                        OwnerInfoId = g.Key.OwnerInfoId,
        //                        OwnerInfoName = g.Key.OwnerInfoName,
        //                        DeedQty = g.Count(),
        //                        TotalLandAcres = (decimal)(g.Sum(c => c.LandAmount)) / 100
        //                    }).ToList();

        //        if (DivisionId != Guid.Empty)
        //        {
        //            data = data.Where(x => x.DivisionId == DivisionId ).ToList();
        //        }
        //        if (DistrictId != Guid.Empty)
        //        {
        //            data = data.Where(x => x.DivisionId == DivisionId && x.DistrictId == DistrictId).ToList();
        //        }
        //        if (UpozilaId != Guid.Empty)
        //        {
        //            data = data.Where(x => x.DivisionId == DivisionId && x.DistrictId == DistrictId && x.UpozilaId == UpozilaId).ToList();
        //        }
        //        if (MouzaId != Guid.Empty)
        //        {
        //            data = data.Where(x => x.DivisionId == DivisionId && x.DistrictId == DistrictId && x.UpozilaId == UpozilaId && x.MouzaId == MouzaId).ToList();
        //        }
        //        if (OwnerInfoId != Guid.Empty)
        //        {
        //            data = data.Where(x => x.DivisionId == DivisionId && x.DistrictId == DistrictId && x.UpozilaId == UpozilaId && x.MouzaId == MouzaId && x.OwnerInfoId == OwnerInfoId).ToList();
        //        }
        //        var res = KendoGrid<GetAllLandSummaryByIdVm>.DataSource(options, data.AsQueryable().OrderBy(o => o.DivisionName));
        //        return await Task.FromResult(res);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}

        public async Task<GridEntity<GetAllLandSummaryByDivisionIdVm>> GetAllLandSummaryByDivisionIdGridAsync(GridOptions options, Guid divisionId)
        {
            try
            {

                var data = (from lm in _dbContext.LandMasters
                            join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                            from div in division.DefaultIfEmpty()
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                            from d in district.DefaultIfEmpty()
                            where (lm.IsBayna == false && lm.IsDeleted == false && lm.DivisionId == divisionId)
                            group new
                            {
                                lm.DivisionId,
                                div.DivisionName,
                                lm.DistrictId,
                                d.DistrictName,
                                lm.TotalLandAmount
                            }
                             by new
                             {
                                 lm.DivisionId,
                                 div.DivisionName,
                                 lm.DistrictId,
                                 d.DistrictName
                             } into g
                            select new GetAllLandSummaryByDivisionIdVm
                            {
                                DivisionId = g.Key.DivisionId,
                                DivisionName = g.Key.DivisionName,
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                DeedQty = g.Count(),
                                TotalLandAmount = (decimal)(g.Sum(c => c.TotalLandAmount)) / 100
                            }).ToList();
                var res = KendoGrid<GetAllLandSummaryByDivisionIdVm>.DataSource(options, data.AsQueryable());
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GridEntity<GetLandSummaryByDistrictIdVm>> GetAllLandSummaryByDistrictIdGridAsync(GridOptions options, Guid districtId)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into landms
                            from d in landms.DefaultIfEmpty()
                            join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                            from div in division.DefaultIfEmpty()
                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()
                            where (lm.IsBayna == false && lm.IsDeleted == false && lm.DistrictId == districtId)

                            group new
                            {
                                lm.DivisionId,
                                div.DivisionName,
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                                lm.TotalLandAmount
                            }
                            by new
                            {
                                lm.DivisionId,
                                div.DivisionName,
                                lm.DistrictId,
                                d.DistrictName,
                                lm.UpozilaId,
                                u.UpozilaName,
                            } into g
                            select new GetLandSummaryByDistrictIdVm
                            {
                                DivisionId = g.Key.DivisionId,
                                DivisionName = g.Key.DivisionName,
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                DeedQty = g.Count(),
                                TotalLandAcres = (decimal)g.Sum(c => c.TotalLandAmount) / 100
                            }).ToList();
                var res = KendoGrid<GetLandSummaryByDistrictIdVm>.DataSource(options, data.AsQueryable());
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //public async Task<GridEntity<GetAllLandSummaryByUpozilaIdVm>> GetAllLandSummaryByUpozilaIdGridAsync(GridOptions options, Guid upozilaId)
        //{


        //    try
        //    {
        //        var data = (from lm in _dbContext.LandMasters
        //                    join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into landms
        //                    from d in landms.DefaultIfEmpty()
        //                    join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
        //                    from div in division.DefaultIfEmpty()
        //                    join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
        //                    from u in upozila.DefaultIfEmpty()
        //                    join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into lodowner
        //                    from lod in lodowner.DefaultIfEmpty()
        //                    join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into cmnMouzas
        //                    from m in cmnMouzas.DefaultIfEmpty()
        //                    where (lm.IsBayna == false && lm.IsDeleted == false && lm.UpozilaId == upozilaId)
        //                    group new
        //                    {
        //                        lm.DivisionId,
        //                        div.DivisionName,
        //                        lm.DistrictId,
        //                        d.DistrictName,
        //                        lm.UpozilaId,
        //                        u.UpozilaName,
        //                        m.MouzaId,
        //                        m.MouzaName,
        //                        lm.TotalLandAmount
        //                    }
        //                    by new
        //                    {
        //                        lm.DivisionId,
        //                        div.DivisionName,
        //                        lm.DistrictId,
        //                        d.DistrictName,
        //                        lm.UpozilaId,
        //                        u.UpozilaName,
        //                        m.MouzaId,
        //                        m.MouzaName
        //                    } into g
        //                    select new GetAllLandSummaryByUpozilaIdVm
        //                    {
        //                        DivisionId = g.Key.DivisionId,
        //                        DivisionName = g.Key.DivisionName,
        //                        DistrictId = g.Key.DistrictId,
        //                        DistrictName = g.Key.DistrictName,
        //                        UpozilaId = g.Key.UpozilaId,
        //                        UpozilaName = g.Key.UpozilaName,
        //                        MouzaId = g.Key.MouzaId,
        //                        MouzaName = g.Key.MouzaName,
        //                        DeedQty = g.Count(),
        //                        TotalLandAmount = (decimal)g.Sum(c => c.TotalLandAmount) / 100
        //                    }).ToList();
        //        var res = KendoGrid<GetAllLandSummaryByUpozilaIdVm>.DataSource(options, data.AsQueryable());
        //        return await Task.FromResult(res);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
            
        //}

        //public async Task<GridEntity<GetLandSummaryByMouzaIdVm>> GetAllLandSummaryByMouzaIdGridAsync(GridOptions options, Guid mouzaId)
        //{
        //    try
        //    {
        //        var data = (from lm in _dbContext.LandMasters
        //                    join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into landms
        //                    from d in landms.DefaultIfEmpty()
        //                    join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
        //                    from div in division.DefaultIfEmpty()
        //                    join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
        //                    from u in upozila.DefaultIfEmpty()
        //                    join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into lodowner
        //                    from lod in lodowner.DefaultIfEmpty()
        //                    join o in _dbContext.OwnerInfos on lod.OwnerInfoId equals o.OwnerInfoId into owner
        //                    from o in owner.DefaultIfEmpty()
        //                    join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into cmnMouzas
        //                    from m in cmnMouzas.DefaultIfEmpty()
        //                    where (lm.IsBayna == false && lm.IsDeleted == false && lod.MouzaId == mouzaId)
        //                    group new
        //                    {
        //                        lm.DivisionId,
        //                        div.DivisionName,
        //                        lm.DistrictId,
        //                        d.DistrictName,
        //                        lm.UpozilaId,
        //                        u.UpozilaName,
        //                        m.MouzaId,
        //                        m.MouzaName,
        //                        o.OwnerInfoId,
        //                        o.OwnerInfoName,
        //                        lod.LandAmount
        //                    }
        //                    by new
        //                    {
        //                        lm.DivisionId,
        //                        div.DivisionName,
        //                        lm.DistrictId,
        //                        d.DistrictName,
        //                        lm.UpozilaId,
        //                        u.UpozilaName,
        //                        m.MouzaId,
        //                        m.MouzaName,
        //                        o.OwnerInfoId,
        //                        o.OwnerInfoName,
        //                    } into g
        //                    select new GetLandSummaryByMouzaIdVm
        //                    {
        //                        DivisionId = g.Key.DivisionId,
        //                        DivisionName = g.Key.DivisionName,
        //                        DistrictId = g.Key.DistrictId,
        //                        DistrictName = g.Key.DistrictName,
        //                        UpozilaId = g.Key.UpozilaId,
        //                        UpozilaName = g.Key.UpozilaName,
        //                        MouzaId = g.Key.MouzaId,
        //                        MouzaName = g.Key.MouzaName,
        //                        OwnerInfoId = g.Key.OwnerInfoId,
        //                        OwnerInfoName = g.Key.OwnerInfoName,
        //                        DeedQty = g.Count(),
        //                        TotalLandAmount = (decimal)g.Sum(c => c.LandAmount) / 100
        //                    }).ToList();
        //        var res = KendoGrid<GetLandSummaryByMouzaIdVm>.DataSource(options, data.AsQueryable());
        //        return await Task.FromResult(res);                
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}

        public async Task<GridEntity<GetLandSummaryByOwnerIdVm>> GetAllLandSummaryByOwnerIdGridAsync(GridOptions options,Guid? mouzaId, Guid ownerInfoId)
        {
            try
            {
                var data = (from lm in _dbContext.LandMasters
                            join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                            from div in division.DefaultIfEmpty()
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                            from d in district.DefaultIfEmpty()
                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into ownerDetail
                            from lod in ownerDetail.DefaultIfEmpty()
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into mouza
                            from m in mouza.DefaultIfEmpty()
                            join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owner
                            from oi in owner.DefaultIfEmpty()
                            where (lm.IsBayna == false && lm.IsDeleted == false)
                            group new
                            {
                                lm.DivisionId,
                                div.DivisionName,
                                lm.DistrictId,
                                d.DistrictName,
                                u.UpozilaName,
                                m.MouzaName,
                                oi.OwnerInfoName,
                                lod.LandAmount
                            }
                             by new
                             {
                                 lm.DivisionId,
                                 div.DivisionName,
                                 lm.DistrictId,
                                 d.DistrictName,
                                 lm.UpozilaId,
                                 u.UpozilaName,
                                 m.MouzaId,
                                 m.MouzaName,
                                 oi.OwnerInfoId,
                                 oi.OwnerInfoName
                             } into g
                            select new GetLandSummaryByOwnerIdVm
                            {
                                DivisionId = g.Key.DivisionId,
                                DivisionName = g.Key.DivisionName,
                                DistrictId = g.Key.DistrictId,
                                DistrictName = g.Key.DistrictName,
                                UpozilaId = g.Key.UpozilaId,
                                UpozilaName = g.Key.UpozilaName,
                                MouzaId = g.Key.MouzaId,
                                MouzaName = g.Key.MouzaName,
                                OwnerInfoId = g.Key.OwnerInfoId,
                                OwnerInfoName = g.Key.OwnerInfoName,
                                DeedQty = g.Count(),
                                LandAmount = (decimal)(g.Sum(c => c.LandAmount)) / 100
                            }).ToList();
                if (mouzaId != Guid.Empty)
                {
                    data = data.Where(x => x.MouzaId == mouzaId && x.OwnerInfoId == ownerInfoId).ToList();
                }
                if (ownerInfoId != Guid.Empty && mouzaId == Guid.Empty)
                {
                    data = data.Where(x => x.OwnerInfoId == ownerInfoId).ToList();
                }
                var res = KendoGrid<GetLandSummaryByOwnerIdVm>.DataSource(options, data.AsQueryable());
                return await Task.FromResult(res);

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<bool> IsDeedExist(Guid SubRegOfficeId, string DeedNo, string EntryDate)
        {
            try
            {
                var date = DateTime.Parse(EntryDate).Year;
                var existsdata = (await _dbContext.LandMasters.AsNoTracking()
                    .Where(f => f.IsDeleted == false && f.SubRegOfficeId == SubRegOfficeId && f.DeedNo == DeedNo && f.EntryDate.Value.Year == date).AnyAsync());
               return existsdata != false ? true : false;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //public async Task<GridEntity<GetLandInfoGlobalSearchVm>> GetAllLandSummaryGlobalGridAsync(GridOptions options)
        //{
        //    try
        //    {
        //        var list = (from lm in _dbContext.LandMasters
        //                    join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
        //                    from div in division.DefaultIfEmpty()
        //                    join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
        //                    from d in district.DefaultIfEmpty()
        //                    join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
        //                    from u in upozila.DefaultIfEmpty()
        //                    join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into ownerDetail
        //                    from lod in ownerDetail.DefaultIfEmpty()
        //                    join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into mouza
        //                    from m in mouza.DefaultIfEmpty()
        //                    join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owner
        //                    from oi in owner.DefaultIfEmpty()
        //                    join fld in _dbContext.FileLocationDetails on lm.LandMasterId equals fld.LandMasterId into fileloc
        //                    from fld in fileloc.DefaultIfEmpty()
        //                    join flm in _dbContext.FileLocationMasters on fld.FileLocationMasterId equals flm.FileLocationMasterId into filelocms
        //                    from flm in filelocms.DefaultIfEmpty()
        //                    join fi in _dbContext.FileNoInfos on flm.FileNoInfoId equals fi.FileNoInfoId into fileno
        //                    from fi in fileno.DefaultIfEmpty()
        //                    join lor in _dbContext.LandMasterOwnerRelations on lm.LandMasterId equals lor.LandMasterId into ownerRelation
        //                    from lor in ownerRelation.DefaultIfEmpty()
        //                    join lot in _dbContext.LandOwnerTypes on lor.LandOwnerTypeId equals lot.LandOwnerTypeId into landown
        //                    from lot in landown.DefaultIfEmpty()
        //                    join omd in _dbContext.OwnerWiseMutationDetails on lm.LandMasterId equals omd.LandMasterId into ownermute
        //                    from omd in ownermute.DefaultIfEmpty()
        //                    join pmd in _dbContext.PlotWiseMutationDetails on lm.LandMasterId equals pmd.LandMasterId into plotemute
        //                    from pmd in plotemute.DefaultIfEmpty()
        //                    join kt in _dbContext.KhatianTypes on pmd.KhatianTypeId equals kt.KhatianTypeId into ktype
        //                    from kt in ktype.DefaultIfEmpty()
        //                    join mm in _dbContext.MutationMasters on omd.MutationMasterId equals mm.MutationMasterId into mutationms
        //                    from mm in mutationms.DefaultIfEmpty()
        //                    join ldt in _dbContext.LandDevelopmentTaxes on mm.MutationMasterId equals ldt.MutationMasterId into tax
        //                    from ldt in tax.DefaultIfEmpty()
        //                    join cb in _dbContext.CmnBanglaYears on ldt.FromDate equals cb.BanglaYearId into year
        //                    from cb in year.DefaultIfEmpty()
        //                    group new
        //                    {
        //                        //lm.LandMasterId,
        //                        //fi.FileNoInfoId,
        //                        fi.FileNoInfoName,
        //                        //lot.LandOwnerTypeId,
        //                        lot.LandOwnerTypeName,
        //                        //lm.DivisionId,
        //                        div.DivisionName,
        //                        //lm.DistrictId,
        //                        d.DistrictName,
        //                        //lm.UpozilaId,
        //                        u.UpozilaName,
        //                        //lod.MouzaId,
        //                        m.MouzaName,
        //                        //oi.OwnerInfoId,
        //                        oi.OwnerInfoName,
        //                        lm.DeedNo,
        //                        lm.EntryDate,
        //                        lod.LandAmount,
        //                        omd.OwnerMutatedLandAmount,
        //                        //kt.KhatianTypeId,
        //                        kt.KhatianTypeName,
        //                        pmd.KhatianNo,
        //                        pmd.DagNo,
        //                        mm.HoldingNo,
        //                        //cb.BanglaYearId,
        //                        cb.BanglaYearName
        //                    }
        //                    by new
        //                    {
        //                        lm.LandMasterId,
        //                        fi.FileNoInfoId,
        //                        fi.FileNoInfoName,
        //                        lot.LandOwnerTypeId,
        //                        lot.LandOwnerTypeName,
        //                        div.DivisionId,
        //                        div.DivisionName,
        //                        d.DistrictId,
        //                        d.DistrictName,
        //                        u.UpozilaId,
        //                        u.UpozilaName,
        //                        //m.MouzaId,
        //                        m.MouzaName,
        //                        //oi.OwnerInfoId,
        //                        oi.OwnerInfoName,
        //                        lm.DeedNo,
        //                        lm.EntryDate,
        //                        lod.LandAmount,
        //                        omd.OwnerMutatedLandAmount,
        //                        kt.KhatianTypeId,
        //                        kt.KhatianTypeName,
        //                        pmd.KhatianNo,
        //                        pmd.DagNo,
        //                        mm.HoldingNo,
        //                        cb.BanglaYearId,
        //                        cb.BanglaYearName
        //                    } into g
        //                    select new GetLandInfoGlobalSearchVm {
        //                        LandMasterId = g.Key.LandMasterId,
        //                        FileNoInfoId = g == null ? Guid.Empty : g.Key.FileNoInfoId,
        //                        FileNoInfoName = g == null ? 0 :  g.Key.FileNoInfoName,
        //                        LandOwnerTypeId = g.Key.LandOwnerTypeId,
        //                        LandOwnerTypeName = g.Key.LandOwnerTypeName,
        //                        DivisionId = g.Key.DivisionId,
        //                        DivisionName = g.Key.DivisionName,
        //                        DistrictId = g.Key.DistrictId,
        //                        DistrictName = g.Key.DistrictName,
        //                        UpozilaId = g.Key.UpozilaId,
        //                        UpozilaName = g.Key.UpozilaName,
        //                        //MouzaId = g.Key.MouzaId,
        //                        //MouzaName = g.Key.MouzaName,
        //                        MouzaName = string.Join(", ", g.Select(i => i.MouzaName)),
        //                        //OwnerInfoId = g.Key.OwnerInfoId,
        //                        //OwnerInfoName = g.Key.OwnerInfoName,
        //                        OwnerInfoName = string.Join(", ", g.Select(i => i.OwnerInfoName)),
        //                        DeedNo = g.Key.DeedNo,
        //                        EntryDate = Convert.ToDateTime(g.Key.EntryDate).ToString("dd-MM-yyyy"),
        //                        TotalLandAmount = (decimal)(g.Sum(c => c.LandAmount)),
        //                        OwnerMutatedLandAmount = g == null ? 0 : (decimal)(g.Sum(c => c.OwnerMutatedLandAmount)),
        //                        KhatianTypeId = g == null ? Guid.Empty : g.Key.KhatianTypeId,
        //                        KhatianTypeName = g == null ? "" : g.Key.KhatianTypeName,
        //                        //KhatianNo = g.Key.KhatianNo,
        //                        //DagNo = g.Key.DagNo,
        //                        //KhatianNo = g == null ? "" : string.Join(", ", g.Select(i => i.KhatianNo)),
        //                        //DagNo = g == null ? "" : string.Join(", ", g.Select(i => i.DagNo)),
        //                        HoldingNo = g == null ? "0" : g.Key.HoldingNo,
        //                        BanglaYearId = g == null ? Guid.Empty : g.Key.BanglaYearId,
        //                        BanglaYearName = g == null ? "" : g.Key.BanglaYearName
        //                    }).OrderBy(o=> o.DeedNo).ToList().AsQueryable();
        //        var res = KendoGrid<GetLandInfoGlobalSearchVm>.DataSource(options, list);
        //        return await Task.FromResult(res);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}

        public async Task<GridEntity<GetLandInformationsByDeedNoVm>> GetAllLandInformationsByDeedGrid(GridOptions options, string deedNo)
        {
            try
            {
                var list = (from lm in _dbContext.LandMasters
                            join div in _dbContext.CmnDivisions on lm.DivisionId equals div.DivisionId into division
                            from div in division.DefaultIfEmpty()
                            join d in _dbContext.CmnDistricts on lm.DistrictId equals d.DistrictId into district
                            from d in district.DefaultIfEmpty()
                            join u in _dbContext.CmnUpozilas on lm.UpozilaId equals u.UpozilaId into upozila
                            from u in upozila.DefaultIfEmpty()
                            join lod in _dbContext.LandOwnersDetails on lm.LandMasterId equals lod.LandMasterId into ownerDetail
                            from lod in ownerDetail.DefaultIfEmpty()
                            join m in _dbContext.CmnMouzas on lod.MouzaId equals m.MouzaId into mouza
                            from m in mouza.DefaultIfEmpty()
                            join oi in _dbContext.OwnerInfos on lod.OwnerInfoId equals oi.OwnerInfoId into owner
                            from oi in owner.DefaultIfEmpty()
                            join kd in _dbContext.KhatianDetails on lm.LandMasterId equals kd.LandMasterId into katian
                            from kd in katian.DefaultIfEmpty()
                            where (lm.DeedNo == deedNo && lm.IsDeleted == false)
                            select new GetLandInformationsByDeedNoVm
                            {
                                LandMasterId = lm.LandMasterId,
                                DivisionId = div.DivisionId,
                                DivisionName = div.DivisionName,
                                DistrictId = d.DistrictId,
                                DistrictName = d.DistrictName,
                                UpozilaId = u.UpozilaId,
                                UpozilaName = u.UpozilaName,
                                MouzaId = m.MouzaId,
                                MouzaName = m.MouzaName,
                                OwnerInfoId = oi.OwnerInfoId,
                                OwnerInfoName = oi.OwnerInfoName,
                                EntryDate = lm.EntryDate,
                                DeedNo = lm.DeedNo,
                                LandAmount = lod.LandAmount,
                                KhatianNo = kd.KhatianNo,
                                DagNo = kd.DagNo,
                                RecordedOwnerName = kd.RecordedOwnerName
                            }).OrderBy(o => o.DeedNo).ToList().AsQueryable();
                var res = KendoGrid<GetLandInformationsByDeedNoVm>.DataSource(options, list);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

    }
}
