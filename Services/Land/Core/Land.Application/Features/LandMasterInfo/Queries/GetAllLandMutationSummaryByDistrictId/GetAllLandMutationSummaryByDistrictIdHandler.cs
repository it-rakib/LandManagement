using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDivisionId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDistrictId
{
    public class GetAllLandMutationSummaryByDistrictIdHandler : IRequestHandler<GetAllLandMutationSummaryByDistrictIdQuery,GridEntity<GetAllLandMutationSummaryByDistrictIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetAllLandMutationSummaryByDistrictIdHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetAllLandMutationSummaryByDistrictIdVm>> Handle(GetAllLandMutationSummaryByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.districtId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetAllLandMutationSummaryByDistrictIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_District_Mutation_Grid_By_Id", "get_District_Mutation_Summary", "DistrictName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
