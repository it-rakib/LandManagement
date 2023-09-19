using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByUpozilaId;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandSummarySingleGridByOwnerId
{
    public class GetSingleLandSummaryByOwnerIdQueryHandler : IRequestHandler<GetSingleLandSummaryByOwnerIdQuery,GridEntity<GetLandSummaryByOwnerIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetSingleLandSummaryByOwnerIdQueryHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetLandSummaryByOwnerIdVm>> Handle(GetSingleLandSummaryByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.OwnerInfoId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetLandSummaryByOwnerIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Owner_Mutation_Grid_By_Id", "get_Owner_Single_Summary", "OwnerInfoName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
