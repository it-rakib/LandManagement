using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo
{
    public class GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNoQueryHandler
        : IRequestHandler<GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNoQuery, decimal>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNoQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<decimal> Handle(GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo(request.SaleLandMasterId, request.SaleKhatianTypeId, request.SaleDagNo);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
