using Common.Service.CommonEntities.KendoGrid;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDocument;
using Land.Application.Features.LandMapInfo.Queries.GetAllMapInfoGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class LandMapRepository : BaseRepository<LandMap>, ILandMapRepository
    {
        public LandMapRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<GridEntity<GetAllMapInfoGridVm>> GetAllMapGrid(GridOptions options)
        {
            try
            {
                var data = _dbContext.LandMaps
                    .Where(f=> f.IsDeleted == false)
                    .Include(i => i.Division)
                    .Include(j => j.District)
                    .Include(k => k.Upozila)
                    .Include(l => l.Mouza)
                    .Include(m => m.SheetNoInfo)
                    .Include(n=> n.MapType)
                    .AsNoTracking()
                    .Select(s => new GetAllMapInfoGridVm
                    {
                        LandMapId = s.LandMapId,
                        DivisionId = s.DivisionId,
                        DivisionName = s.Division.DivisionName,
                        DistrictId = s.DistrictId,
                        DistrictName = s.District.DistrictName,
                        UpozilaId = s.UpozilaId,
                        UpozilaName = s.Upozila.UpozilaName,
                        MouzaId = s.MouzaId,
                        MouzaName = s.Mouza.MouzaName,
                        MapTypeId = s.MapTypeId,
                        MapTypeName = s.MapType.MapTypeName,
                        //MapType = s.MapType,
                       
                        SheetNoInfoId = s.SheetNoInfoId,
                        SheetNo = s.SheetNoInfo.SheetNo,
                        Remarks = s.Remarks,
                        FileRemarks = s.FileRemarks,
                        FilesVm = _dbContext.CmnDocumentFiles.Where(x => x.ModuleMasterId == s.LandMapId && x.ModuleName == "LandMap").AsNoTrackingWithIdentityResolution()
                                                    .Select(f => new FilesVm()
                                                    {
                                                        name = f.FileName,
                                                        size = (int)f.FileSize,
                                                        extension = f.FileExtension,
                                                        docId = f.DocumentId,
                                                        fileUniq = f.FileUniqueName
                                                    }).ToList()
                    }).OrderBy(o=>o.SheetNo).AsQueryable();
                var res = KendoGrid<GetAllMapInfoGridVm>.DataSource(options, data);
                return await Task.FromResult(res);

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public async Task<LandMap> GetLandMapById(Guid landMapId)
        {
            try
            {
                var data = await _dbContext.LandMaps.AsNoTracking().Where(f => f.LandMapId == landMapId).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //public async Task<LandMap> UpdateLandMap(LandMap landMap)
        //{
        //    try
        //    {
        //        Guid landMapId = landMap.LandMapId;
        //        var landMapKhatianRelation = landMap.LandMapKhatianRelations.ToList();

        //        RemoveLandMasterOwnerRelation(landMapKhatianRelation, landMapId);

        //        _dbContext.Entry(landMap).State = EntityState.Modified;
        //        //_dbContext.LandMaps.Update(landMap);
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }

        //    return landMap;
        //}

        //public void RemoveLandMasterOwnerRelation(List<LandMapKhatianRelation> lm, Guid landMapId)
        //{
        //    var removeData = _dbContext.LandMapKhatianRelations.AsNoTracking().Where(s => s.LandMapId == landMapId ).ToList();
        //    _dbContext.LandMapKhatianRelations.RemoveRange(removeData);
        //    _dbContext.SaveChanges();

        //    var newRelation = new List<LandMapKhatianRelation>();
        //    foreach(var item in lm)
        //    {
        //        item.LandMapId=landMapId;
        //        newRelation.Add(item);
        //    }
        //    _dbContext.LandMapKhatianRelations.AddRange(newRelation);
        //    _dbContext.SaveChanges();

        //}

        public async Task<bool> IsMapExist(Guid landMapId)
        {
            try
            {
                var data = await _dbContext.LandMaps.AsNoTracking()
                    .Where(s => s.LandMapId == landMapId).AnyAsync();
                return data != false ? true : false;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
