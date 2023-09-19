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

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByUpozilaId
{
    public class GetAllLandMutationSummaryByUpozilaHandler : IRequestHandler<GetAllLandMutationSummaryByUpozilaIdQuery,GridEntity<GetAllLandMutationSummaryByUpozilaIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetAllLandMutationSummaryByUpozilaHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetAllLandMutationSummaryByUpozilaIdVm>> Handle(GetAllLandMutationSummaryByUpozilaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.UpozilaId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetAllLandMutationSummaryByUpozilaIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Upozila_Mutation_Grid_By_Id", "get_Upozila_Mutation_Summary", "UpozilaName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
