using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDivisionId;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByMouzaId
{
    public class GetLandSummaryByMouzaIdQueryHandler : IRequestHandler<GetLandSummaryByMouzaIdQuery, GridEntity<GetLandSummaryByMouzaIdVm>>
    {
        private readonly IDapperRepository _dapperRepository;

        public GetLandSummaryByMouzaIdQueryHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetLandSummaryByMouzaIdVm>> Handle(GetLandSummaryByMouzaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.MouzaId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetLandSummaryByMouzaIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Mouza_Grid_By_Id", "get_Mouza_Summary", "MouzaName", sp_params));
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }




        //public async Task<GridEntity<GetLandSummaryByMouzaIdVm>> Handle(GetLandSummaryByMouzaIdQuery request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _landMasterRepository.GetAllLandSummaryByMouzaIdGridAsync(request.options, request.MouzaId);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
    }
}
