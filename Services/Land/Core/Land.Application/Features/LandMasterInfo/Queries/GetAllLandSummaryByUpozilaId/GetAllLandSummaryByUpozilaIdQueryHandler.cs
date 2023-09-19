using Common.Service.CommonEntities;
using Common.Service.CommonEntities.KendoGrid;
using Dapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByUpozilaId;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByUpozilaId
{
    public class GetAllLandSummaryByUpozilaIdQueryHandler : IRequestHandler<GetAllLandSummaryByUpozilaIdQuery,GridEntity<GetAllLandSummaryByUpozilaIdVm>>
    {
        //private readonly ILandMasterRepository _landMasterRepository;
        private readonly IDapperRepository _dapperRepository;

        public GetAllLandSummaryByUpozilaIdQueryHandler(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository ?? throw new ArgumentNullException(nameof(dapperRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryByUpozilaIdVm>> Handle(GetAllLandSummaryByUpozilaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DynamicParameters sp_params = new DynamicParameters();
                sp_params.Add("@param1", request.UpozilaId);

                var result = await Task.FromResult(_dapperRepository.GetGridData_Sp<GetAllLandSummaryByUpozilaIdVm>(request.options, ConStrManager.Land.GetString(), "sp_Select_Upozila_Grid_By_Id", "get_Upozila_Summary", "UpozilaName", sp_params));
                return result;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }


        //public GetAllLandSummaryByUpozilaIdQueryHandler(ILandMasterRepository landMasterRepository)
        //{
        //    _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        //}

        //public async Task<GridEntity<GetAllLandSummaryByUpozilaIdVm>> Handle(GetAllLandSummaryByUpozilaIdQuery request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _landMasterRepository.GetAllLandSummaryByUpozilaIdGridAsync(request.options,request.UpozilaId);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
    }
}
