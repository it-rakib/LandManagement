using AutoMapper;
using Land.Application.Features.AlmirahNo.Queries.GetAllAlmirahNoList;
using Land.Application.Features.CmnBanglaYearInfo.Queries.GetAllCmnBanglaYearList;
using Land.Application.Features.CmnDistrictInfo.Commands.CreateUpdateCmnDistrict;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictList;
using Land.Application.Features.CmnDivisionInfo.Commands.CreateUpdateCmnDivision;
using Land.Application.Features.CmnDivisionInfo.Commands.DeleteCmnDivision;
using Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionList;
using Land.Application.Features.CmnDivisionInfo.Queries.GetCmnDivisionById;
using Land.Application.Features.CmnDocument;
using Land.Application.Features.CmnMouzaInfo.Commands.CreateUpdateCmnMouza;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId;
using Land.Application.Features.CmnSubRegOfficeInfo.Commands.CreateUpdateCmnSubRegOffice;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId;
using Land.Application.Features.CmnUpozilaInfo.Commands.CreateUpdateCmnUpozila;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId;
using Land.Application.Features.FileCode.Commands.CreateUpdateFileCode;
using Land.Application.Features.FileCode.Queries.GetAllFileCodeList;
using Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId;
using Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId;
using Land.Application.Features.KhatiyanTypeInfo.Queries.GetAllKhatiyanTypes;
using Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax;
using Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap;
using Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster;
using Land.Application.Features.LandMasterInfo.Queries.GetAllBayaDeedDetailListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoByOwnerInfoId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoList;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoListByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterIdMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandDetailListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandOwnerListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSalerInfoListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictList;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpazilaByUpazilaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandSaleDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandTransferDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandSaleDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandTransferDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllUpozilaByDistrictIdList;
using Land.Application.Features.LandMasterInfo.Queries.GetLandInformationsByDeedNo;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId;
using Land.Application.Features.LandOwnerInfo.Commands.CreateUpdateLandOwner;
using Land.Application.Features.LandOwnerInfo.Commands.DeleteLandOwner;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoList;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerMouzaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId;
using Land.Application.Features.MapTypeInfo.Queries.MapTypeListCombo;
using Land.Application.Features.MutationMasterInfo.Commands.CreateOrUpdateMutationMaster;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllDagNoListByLandMasterKhatianType;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllHoldingNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId;
using Land.Application.Features.MutationMasterInfo.Queries.GetMutationMasterById;
using Land.Application.Features.SheetNo.Queries;
using Land.Domain.Models;

namespace Merchandising.Application.Profiles
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            //Cmn Division Map
            CreateMap<CmnDivision, CmnDivisionListVm>().ReverseMap();
            CreateMap<CmnDivision, CmnDivisionByIdVM>().ReverseMap();
            CreateMap<CmnDivision, CreateCmnDivisionDTO>().ReverseMap();
            CreateMap<CmnDivision, DeleteCmnDivisionCommand>().ReverseMap();

            //Cmn District Map
            CreateMap<CmnDistrict, CmnDistrictListVm>().ReverseMap();
            CreateMap<CmnDistrict, CmnDistrictByDivisionIdVM>().ReverseMap();
            CreateMap<CmnDistrict, CreateCmnDistrictDTO>().ReverseMap();

            //Cmn Upozila Map
            CreateMap<CmnUpozila, CreateCmnUpozilaDTO>().ReverseMap();
            CreateMap<CmnUpozila, CmnUpozilaByDistrictIdVM>().ReverseMap();
            
            //Cmn Mouza Map
            CreateMap<CmnMouza, CreateCmnMouzaDTO>().ReverseMap();
            CreateMap<CmnMouza, CmnMouzaByUpozilaIdVM>().ReverseMap();

            //LandOwnerType Map
            CreateMap<LandOwnerType, GetAllLandOwnerTypeListVm>().ReverseMap();
            CreateMap<LandOwnerType, LandOwnerTypeListByLandMasterIdVm>().ReverseMap();

            //LandMaster Map
            CreateMap<LandMaster, CreateOrUpdateLandMasterDto>().ReverseMap();
            CreateMap<LandSalersInfo, LandSalerInfoListByLandMasterIdVm>().ReverseMap();
            CreateMap<KhatianDetail, KhatianDetailListByLandMasterIdVm>().ReverseMap();
            CreateMap<KhatianDetail, KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>().ReverseMap();
            CreateMap<KhatianDetail, KhatianTypeListByLandMasterIdMouzaIdVm>().ReverseMap();
            CreateMap<LandOwnersDetail, LandOwnerListByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, DeedNoListByMouzaIdVm>().ReverseMap();
            CreateMap<LandMaster, GetAllLandSummaryDistrictListVm>().ReverseMap();
            CreateMap<LandMaster, GetAllUpozilaByDistrictIdListVm>().ReverseMap();
            CreateMap<LandMaster, DeedNoByOwnerInfoIdVm>().ReverseMap();
            CreateMap<LandMaster, KhatianTypeListByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, PlotWiseLandTransferDetailByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, OwnerWiseLandTransferDetailByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, AllDeedNoListVm>().ReverseMap();
            CreateMap<LandMaster, BayaDeedDetailListByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, PlotWiseLandSaleDetailByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, OwnerWiseLandSaleDetailByLandMasterIdVm>().ReverseMap();
            CreateMap<LandMaster, LandSummaryDistrictByDistrictIdVm>().ReverseMap();
            CreateMap<LandMaster, LandSummaryUpazilaByUpazilaIdVm>().ReverseMap();
            CreateMap<LandMaster, LandSummaryMouzaByMouzaIdVm>().ReverseMap();
            //CreateMap<LandMaster, GetAllLandSummaryByIdVm>().ReverseMap();
            CreateMap<LandMaster, GetAllLandSummaryByDivisionIdVm>().ReverseMap();
            CreateMap<LandMaster, GetLandSummaryByDistrictIdVm>().ReverseMap();
           // CreateMap<LandMaster, GetAllLandSummaryByUpozilaIdVm>().ReverseMap();
            //CreateMap<LandMaster, GetLandSummaryByMouzaIdVm>().ReverseMap();
            CreateMap<LandMaster, GetLandSummaryByOwnerIdVm>().ReverseMap();
            CreateMap<LandMaster, GetLandInformationsByDeedNoVm>().ReverseMap();

            //KhatiyanType Map
            CreateMap<KhatianType, GetAllKhatiyanTypesVm>().ReverseMap();

            //OwnerInfo Map
            CreateMap<OwnerInfo, GetAllOwnerInfoListVm>().ReverseMap();
            CreateMap<OwnerInfo, OwnerInfoGridVm>().ReverseMap();
            CreateMap<OwnerInfo, CreateLandOwnerDto>().ReverseMap();
            CreateMap<OwnerInfo, DeleteLandOwnerCommand>().ReverseMap();


            //Sub Reg Office Map
            CreateMap<CmnSubRegOffice, CmnSubRegOfficeByUpozilaIdVM>().ReverseMap();
            CreateMap<CmnSubRegOffice, CreateCmnSubRegOfficeDto>().ReverseMap();

            //Mutation Master Map
            CreateMap<MutationMaster, GetAllMutationMasterGridVm>().ReverseMap();
            CreateMap<MutationMaster, CreateOrUpdateMutationMasterDto>().ReverseMap();
            CreateMap<MutationMaster, OwnerWiseMutationDetailListByMutationMasterIdVm>().ReverseMap();
            CreateMap<MutationMaster, HoldingNoListVm>().ReverseMap();
            CreateMap<MutationMaster, MutationMasterByIdVm>().ReverseMap();
            CreateMap<MutationMaster, PlotWiseMutationDetailListByMutationMasterIdVm>().ReverseMap();
            CreateMap<PlotWiseMutationDetail, MutatedDeedNoListVm>().ReverseMap();
            CreateMap<PlotWiseMutationDetail, DagNoListByLandMasterKhatianTypeVm>().ReverseMap();
            CreateMap<OwnerWiseMutationDetail, TransferedOwnerInfoByLandMasterKhatianTypeIdVm>().ReverseMap();

            //Land Development Tax Map
            CreateMap<LandDevelopmentTax, CreateOrUpdateLandDevelopmentTaxDto>().ReverseMap();

            //Cmn Bangla Year Map
            CreateMap<CmnBanglaYear, CmnBanglaYearVm>().ReverseMap();

           //Land Owners Detail Map
            CreateMap<LandOwnersDetail, LandOwnerDetailByLandMasterIdMouzaIdVm>().ReverseMap();
            CreateMap<LandOwnersDetail, LandSummaryOwnerDistrictListByOwnerInfoIdVm>().ReverseMap();
            CreateMap<LandOwnersDetail, LandSummaryOwnerUpozilaListByOwnerInfoIdVm>().ReverseMap();
            CreateMap<LandOwnersDetail, LandSummaryOwnerMouzaListByOwnerInfoIdVm>().ReverseMap();
            CreateMap<LandOwnersDetail, LandSummaryByLandMasterIdVm>().ReverseMap();

            //File Location Master Map
            CreateMap<FileLocationMaster, CreateFileLocationDto>().ReverseMap();
            CreateMap<FileLocationMaster, FileLocationDetailListByFileLocationMasterIdVm>().ReverseMap();
            CreateMap<FileLocationMaster, FileLocationDetailListVm>().ReverseMap();

            //Cmn File Map
            CreateMap<CmnDocumentFile, DocumentVM>().ReverseMap();

            //File Code Map
            CreateMap<FileCodeInfo, FileCodeListVm>().ReverseMap();
            CreateMap<FileCodeInfo, CreateUpdateFileCodeDTO>().ReverseMap();

            //File Code No
            CreateMap<FileNoInfo, FileNoListByFileCodeIdVm>().ReverseMap();

            //Almirah No
            CreateMap<AlmirahNoInfo, AlmirahNoListVm>().ReverseMap();

            //SheetNoInfo
            CreateMap<SheetNoInfo, GetAllSheetNoInfoListVm>().ReverseMap();

            //Land Map

            CreateMap<LandMap, CreateUpdateLandMapDto>().ReverseMap();

            //Map Type
            CreateMap<MapType, MapTypeListComboVm>().ReverseMap();

        }
    }
}
