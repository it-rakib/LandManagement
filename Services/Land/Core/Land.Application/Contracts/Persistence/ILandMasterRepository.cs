using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ILandMasterRepository : IAsyncRepository<LandMaster>
    {
        Task<LandMaster> GetLandMasterById(Guid LandMasterId);
        Task<LandMaster> UpdateLandMaster(LandMaster landMaster);
        //Task<bool> IsExist(string DeedNo);
        Task<bool> IsDeedExist(Guid SubRegOfficeId,string DeedNo,string EntryDate);
        Task<GridEntity<GetAllLandMasterGridVm>> GetAllMasterGridAsync(GridOptions options);
        Task<List<PlotWiseLandSaleDetailByLandMasterIdVm>> GetAllPlotWiseLandSaleDetailByLandMasterId(Guid landMasterId);
        Task<List<OwnerWiseLandSaleDetailByLandMasterIdVm>> GetAllOwnerWiseLandSaleDetailByLandMasterId(Guid landMasterId);
        Task<List<PlotWiseLandTransferDetailByLandMasterIdVm>> GetAllPlotWiseLandTransferDetailByLandMasterId(Guid landMasterId);
        Task<List<OwnerWiseLandTransferDetailByLandMasterIdVm>> GetAllOwnerWiseLandTransferDetailByLandMasterId(Guid landMasterId);
        
        Task<List<LandSalerInfoListByLandMasterIdVm>> GetAllLandSalerInfoListByLandMasterId(Guid landMasterId);
        Task<List<KhatianDetailListByLandMasterIdVm>> GetAllKhatianDetailListByLandMasterId(Guid landMasterId);
        Task<List<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>> GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId(Guid landMasterId, Guid mouzaId, Guid khatianTypeId);
        Task<List<KhatianTypeListByLandMasterIdMouzaIdVm>> GetAllKhatianTypeListByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId);
        Task<List<KhatianTypeListByLandMasterIdVm>> GetAllKhatianTypeListByLandMasterId(Guid landMasterId);
        Task<List<LandOwnerListByLandMasterIdVm>> GetAllLandOwnerListByLandMasterId(Guid landMasterId);
        Task<List<BayaDeedDetailListByLandMasterIdVm>> GetAllBayaDeedDetailListByLandMasterId(Guid landMasterId);
        //Task<decimal> GetLandAmountByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId);
        Task<decimal> GetLandAmountByLandMasterIdMouzaId(Guid landMasterId,Guid mouzaId);
        Task<List<DeedNoListByMouzaIdVm>> GetDeedNoListByMouzaId(Guid mouzaId);
        Task<List<AllDeedNoListVm>> GetAllDeedNoList();
        Task<decimal> GetTotalLandAmount();
        Task<decimal> GetTotalLandPurchaseAmount();
        Task<int> GetTotalDeed();
        Task<int> GetTotalDistrict();
        Task<int> GetTotalUpozila();
        Task<int> GetTotalMouza();

        Task<GridEntity<GetAllLandSummaryDistrictGridVm>> GetAllLandSummaryDistrictGridAsync(GridOptions options);
        Task<LandSummaryDistrictByDistrictIdVm> GetAllLandSummaryDistrictByDistrictId(Guid districtId);
        Task<List<GetAllLandSummaryDistrictListVm>> GetAllLandSummaryDistrictList();

        Task<List<GetAllUpozilaByDistrictIdListVm>> GetAllUpozilaByDistrictId(Guid districtId);

        Task<GridEntity<LandSummaryUpozilaGridVm>> GetAllLandSummaryUpozilaGridAsync(GridOptions options);
        Task<LandSummaryUpazilaByUpazilaIdVm> GetAllLandSummaryUpazilaByUpazilaId(Guid upozilaId);

        Task<GridEntity<LandSummaryMouzaGridVm>> GetAllLandSummaryMouzaGridAsync(GridOptions options);
        Task<LandSummaryMouzaByMouzaIdVm> GetAllLandSummaryMouzaByMouzaId(Guid mouzaId);

        Task<GridEntity<GetAllLandSummaryOwnerMouzaCommonGridVm>> GetAllLandSummaryOwnerMouzaCommonGrid(GridOptions options);
        Task<GridEntity<GetAllLandSummaryFileDeedOwnerCommonGridVm>> GetAllLandSummaryFileDeedOwnerCommonGrid(GridOptions options);

        Task<List<DeedNoByOwnerInfoIdVm>> GetAllDeedNoByOwnerInfoId(Guid ownerInfoId);
        Task<GridEntity<LandSummaryUpozilaByDistrictIdGridVm>> GetAllLandSummaryUpozilaByDistrictIdGridAsync(GridOptions options, Guid districtId);
        Task<GridEntity<LandSummaryMouzaByUpozilaIdGridVm>> GetAllLandSummaryMouzaByUpozilaIdGridAsync(GridOptions options, Guid upozilaId);
        Task<decimal> GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo(Guid transferedLandMasterId, Guid transferedKhatianTypeId, int transferedDagNo);
        Task<decimal> GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid transferedLandMasterId, Guid transferedKhatianTypeId, Guid transferedOwnerInfoId);
        Task<decimal> GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo(Guid saleLandMasterId, Guid saleKhatianTypeId, int saleDagNo);
        Task<decimal> GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid saleLandMasterId, Guid saleKhatianTypeId, Guid saleOwnerInfoId);
        //Task<GridEntity<GetAllLandSummaryByIdVm>> GetLandSummaryById(GridOptions options, Guid? DivisionId, Guid? DistrictId, Guid? UpozilaId,Guid? MouzaId,Guid? OwnerInfoId);
        Task<GridEntity<GetAllLandSummaryByDivisionIdVm>> GetAllLandSummaryByDivisionIdGridAsync(GridOptions options, Guid divisionId);
        Task<GridEntity<GetLandSummaryByDistrictIdVm>> GetAllLandSummaryByDistrictIdGridAsync(GridOptions options, Guid districtId);
        //Task<GridEntity<GetAllLandSummaryByUpozilaIdVm>> GetAllLandSummaryByUpozilaIdGridAsync(GridOptions options, Guid upozilaId);
        //Task<GridEntity<GetLandSummaryByMouzaIdVm>> GetAllLandSummaryByMouzaIdGridAsync(GridOptions options, Guid mouzaId);
        Task<GridEntity<GetLandSummaryByOwnerIdVm>> GetAllLandSummaryByOwnerIdGridAsync(GridOptions options, Guid? mouzaId, Guid ownerInfoId);
        //Task<GridEntity<GetLandInfoGlobalSearchVm>> GetAllLandSummaryGlobalGridAsync(GridOptions options);
        Task<GridEntity<GetLandInformationsByDeedNoVm>> GetAllLandInformationsByDeedGrid(GridOptions options, string deedNo);
    }
}
