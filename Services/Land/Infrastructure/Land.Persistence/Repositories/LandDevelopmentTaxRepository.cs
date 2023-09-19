using System;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Land.Application.Features.CmnDocument;

namespace Land.Persistence.Repositories
{
    public class LandDevelopmentTaxRepository : BaseRepository<LandDevelopmentTax>, ILandDevelopmentTaxRepository
    {
        public LandDevelopmentTaxRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }
        public async Task<GridEntity<LandDevelopmentTaxGridVm>> GetAllPagingAsync(GridOptions options)
        {
            try
            {
                var data =(from dt in _dbContext.LandDevelopmentTaxes
                           where dt.IsDeleted == false
                           join mm in _dbContext.MutationMasters on dt.MutationMasterId equals mm.MutationMasterId into mutation
                           from mm in mutation.DefaultIfEmpty()

                           join omd in _dbContext.OwnerWiseMutationDetails on mm.MutationMasterId equals omd.MutationMasterId into ownerMutation
                           from omd in ownerMutation.DefaultIfEmpty()

                           join o in _dbContext.OwnerInfos on omd.OwnerInfoId equals o.OwnerInfoId into owner
                           from o in owner.DefaultIfEmpty()

                           join m in _dbContext.CmnMouzas on mm.MouzaId equals m.MouzaId into mouza
                           from m in mouza.DefaultIfEmpty()

                           join u in _dbContext.CmnUpozilas on m.UpozilaId equals u.UpozilaId into upozila
                           from u in upozila.DefaultIfEmpty()

                           join d in _dbContext.CmnDistricts on u.DistrictId equals d.DistrictId into district
                           from d in district.DefaultIfEmpty()

                           join div in _dbContext.CmnDivisions on d.DivisionId equals div.DivisionId into division
                           from div in division.DefaultIfEmpty()

                           join byr in _dbContext.CmnBanglaYears on dt.FromDate equals byr.BanglaYearId into date
                           from byr in date.DefaultIfEmpty()
                           select new LandDevelopmentTaxGridVm
                           {
                               LandDevelopmentTaxId = dt.LandDevelopmentTaxId,
                               MutationMasterId = mm.MutationMasterId,
                               DakhilaNo = dt.DakhilaNo,
                               HoldingNo = mm.HoldingNo,
                               DivisionId = mm.DivisionId,
                               DivisionName = div.DivisionName,
                               DistrictId = mm.DistrictId,
                               DistrictName = d.DistrictName,
                               UpozilaId = u.UpozilaId,
                               UpozilaName = u.UpozilaName,
                               MouzaId = m.MouzaId,
                               MouzaName = m.MouzaName,
                               OwnerInfoId = o.OwnerInfoId,
                               OwnerInfoName = o.OwnerInfoName,
                               EntryDate = dt.EntryDate,
                               FromDate = dt.FromDate,
                               IsDeleted = dt.IsDeleted,
                               FromDateName = _dbContext.CmnBanglaYears.AsNoTracking().Where(w => w.BanglaYearId == dt.FromDate)
                            .Select(k => k.BanglaYearName).FirstOrDefault(),
                               ToDate = dt.ToDate,
                               ToDateName = _dbContext.CmnBanglaYears.AsNoTracking().Where(w => w.BanglaYearId == dt.ToDate)
                            .Select(k => k.BanglaYearName).FirstOrDefault(),
                               TaxAmount = dt.TaxAmount,
                               OwnerMutatedLandAmount = omd.OwnerMutatedLandAmount,
                               CreatedAt = dt.CreatedAt,
                               Remarks = dt.Remarks,
                               FileRemarks = dt.FileRemarks,
                               FilesVm = _dbContext.CmnDocumentFiles.Where(x => x.ModuleMasterId == dt.LandDevelopmentTaxId && x.ModuleName == "Land").AsNoTrackingWithIdentityResolution()
                                                    .Select(f => new FilesVm()
                                                    {
                                                        name = f.FileName,
                                                        size = (int)f.FileSize,
                                                        extension = f.FileExtension,
                                                        docId = f.DocumentId,
                                                        fileUniq = f.FileUniqueName
                                                    }).ToList()
                           }).OrderByDescending(o => o.CreatedAt).ThenBy(tb => tb.HoldingNo).AsQueryable();
                    //_dbContext.LandDevelopmentTaxes.AsNoTracking()
                    //.Include(i => i.MutationMaster)
                    //.Include(j => j.FromDateNavigation)
                    //.Select(s => new LandDevelopmentTaxGridVm
                    //{
                    //    LandDevelopmentTaxId = s.LandDevelopmentTaxId,
                    //    MutationMasterId = s.MutationMasterId,
                    //    DakhilaNo = s.DakhilaNo,
                    //    HoldingNo = s.MutationMaster.HoldingNo,
                    //    DivisionId = s.MutationMaster.DivisionId,
                    //    DivisionName = s.MutationMaster.,
                    //    DistrictId = s.MutationMaster.DistrictId,
                    //    UpozilaId = s.MutationMaster.UpozilaId,
                    //    MouzaId = s.MutationMaster.MouzaId,
                    //    EntryDate = s.EntryDate,
                    //    FromDate = s.FromDate,
                    //    FromDateName = _dbContext.CmnBanglaYears.AsNoTracking().Where(w => w.BanglaYearId == s.FromDate)
                    //        .Select(k => k.BanglaYearName).FirstOrDefault(),
                    //    ToDate = s.ToDate,
                    //    ToDateName =  _dbContext.CmnBanglaYears.AsNoTracking().Where(w => w.BanglaYearId == s.ToDate)
                    //        .Select(k =>k.BanglaYearName).FirstOrDefault(),
                    //    TaxAmount = s.TaxAmount,
                    //    Remarks = s.Remarks,
                    //    FileRemarks = s.FileRemarks,
                    //    CreatedAt = s.CreatedAt,
                    //    FilesVm = _dbContext.CmnDocumentFiles.Where(x => x.ModuleMasterId == s.LandDevelopmentTaxId && x.ModuleName == "Land").AsNoTrackingWithIdentityResolution()
                    //                                .Select(f => new FilesVm()
                    //                                {
                    //                                    name = f.FileName,
                    //                                    size = (int)f.FileSize,
                    //                                    extension = f.FileExtension,
                    //                                    docId = f.DocumentId,
                    //                                    fileUniq = f.FileUniqueName
                    //                                }).ToList()
                    //}).OrderByDescending(o => o.CreatedAt).ThenBy(tb => tb.HoldingNo).AsQueryable();
                var res = KendoGrid<LandDevelopmentTaxGridVm>.DataSource(options, data);
                return await Task.FromResult(res);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<LandDevelopmentTax> GetLandDevelopmentTaxById(Guid landDevelopmentTaxId)
        {
            try
            {
                return await _dbContext.LandDevelopmentTaxes.Where(s => s.LandDevelopmentTaxId == landDevelopmentTaxId).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
