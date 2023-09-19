using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllDagNoListByLandMasterKhatianType;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllHoldingNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId;
using Land.Domain.Models;

namespace Land.Application.Contracts.Persistence
{
    public interface IMutationMasterRepository :IAsyncRepository<MutationMaster>
    {
        Task<bool> IsExist(Guid MutationMasterId, string HoldingNo);
        Task<MutationMaster> GetMutationMasterById(Guid MutationMasterId);
        Task<MutationMaster> UpdateMutationMaster(MutationMaster mutationMaster);
        Task<GridEntity<GetAllMutationMasterGridVm>> GetAllMasterGridAsync(GridOptions options);
        Task<List<PlotWiseMutationDetailListByMutationMasterIdVm>> GetAllPlotWiseMutationDetailListByMutationMasterId(Guid mutationMasterId);
        Task<List<OwnerWiseMutationDetailListByMutationMasterIdVm>> GetAllOwnerWiseMutationDetailListByMutationMasterId(Guid mutationMasterId);
        Task<decimal> GetTotalMutatedLand();
        Task<decimal> GetTotalMutatedLandByLandMasterIdKhatianTypeId(Guid landMasterId, Guid khatianTypeId);
        Task<List<MutatedDeedNoListVm>> GetAllMutatedDeedNoList();
        Task<List<DagNoListByLandMasterKhatianTypeVm>> GetAllDagNoListByLandMasterKhatianType(Guid landMasterId, Guid khatianTypeId);
        Task<decimal> GetTotalPlotWiseMutatedLandAmountByLandMasterKhatianTypeDagNo(Guid landMasterId, Guid khatianTypeId, string dagNo);
        Task<List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>> GetAllTransferedOwnerInfoByLandMasterKhatianTypeId(Guid landMasterId, Guid khatianTypeId);
        Task<decimal> GetTotalOwnerWiseMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid landMasterId, Guid khatianTypeId, Guid ownerInfoId);
        Task<List<HoldingNoListVm>> GetAllHoldingNo();
    }
}
