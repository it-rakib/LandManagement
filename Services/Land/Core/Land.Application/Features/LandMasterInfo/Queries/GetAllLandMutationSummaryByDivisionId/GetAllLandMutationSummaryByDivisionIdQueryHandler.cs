using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDivisionId
{
    public class GetAllLandMutationSummaryByDivisionIdQueryHandler : IRequestHandler<GetAllLandMutationSummaryByDivisionIdQuery,GridEntity<GetAllLandMutationSummaryByDivisionIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetAllLandMutationSummaryByDivisionIdQueryHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetAllLandMutationSummaryByDivisionIdVm>> Handle(GetAllLandMutationSummaryByDivisionIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.DivisionId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetAllLandMutationSummaryByDivisionIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Division_Mutation_Grid_By_Id", "get_Division_Mutation_Summary", "DivisionName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
