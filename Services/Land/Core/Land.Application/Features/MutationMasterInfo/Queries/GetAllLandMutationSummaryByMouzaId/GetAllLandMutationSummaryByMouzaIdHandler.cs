using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDistrictId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByMouzaId
{
    public class GetAllLandMutationSummaryByMouzaIdHandler : IRequestHandler<GetAllLandMutationSummaryByMouzaIdQuery,GridEntity<GetAllLandMutationSummaryByMouzaIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetAllLandMutationSummaryByMouzaIdHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetAllLandMutationSummaryByMouzaIdVm>> Handle(GetAllLandMutationSummaryByMouzaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.mouzaId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetAllLandMutationSummaryByMouzaIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Mouza_Mutation_Grid_By_Id", "get_Mouza_Mutation_Summary", "MouzaName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
