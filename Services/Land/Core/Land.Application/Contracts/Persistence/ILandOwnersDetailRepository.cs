using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryCompanyGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerMouzaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryPersonGrid;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts
{
    public interface ILandOwnersDetailRepository : IAsyncRepository<LandOwnersDetail>
    {
        Task<GridEntity<GetAllLandSummaryPersonGridVm>> GetAllLandSummaryPersonGridAsync(GridOptions options);
        Task<GridEntity<GetAllLandSummaryCompanyGridVm>> GetAllLandSummaryCompanyGridAsync(GridOptions options);
        Task<GridEntity<LandOwnerGridVm>> GetAllLandOwnerGridAsync(GridOptions options);
        Task<List<LandOwnerDetailByLandMasterIdMouzaIdVm>> GetAllLandOwnerDetailByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId);
        Task<List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>> GetAllLandSummaryOwnerDistrictListByOwnerInfoId(Guid ownerInfoId);
        Task<List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>> GetAllLandSummaryOwnerUpozilaListByOwnerInfoId(Guid ownerInfoId);
        Task<List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>> GetAllLandSummaryOwnerMouzaListByOwnerInfoId(Guid ownerInfoId);
        Task<List<LandSummaryByLandMasterIdVm>> GetAllLandSummaryByLandMasterId(Guid landMasterId);
    }
}
