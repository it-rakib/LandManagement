using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByMouzaId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByOwnerInfoId
{
    public class GetAllLandMutationSummaryByOwnerInfoIdQueryHandler : IRequestHandler<GetAllLandMutationSummaryByOwnerInfoIdQuery,GridEntity<GetAllLandMutationSummaryByOwnerInfoIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetAllLandMutationSummaryByOwnerInfoIdQueryHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetAllLandMutationSummaryByOwnerInfoIdVm>> Handle(GetAllLandMutationSummaryByOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.mouzaId);
                sp_params.Add("@param2", request.ownerInfoId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetAllLandMutationSummaryByOwnerInfoIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Owner_Mutation_Grid_By_Id", "get_Owner_Mutation_Summary", "OwnerInfoName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
