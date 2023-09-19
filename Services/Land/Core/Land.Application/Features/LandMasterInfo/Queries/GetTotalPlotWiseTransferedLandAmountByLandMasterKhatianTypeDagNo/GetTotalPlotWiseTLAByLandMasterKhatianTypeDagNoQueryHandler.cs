using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo
{
    public class GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNoQueryHandler
        : IRequestHandler<GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNoQuery, decimal>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNoQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<decimal> Handle(GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo(request.TransferedLandMasterId, request.TransferedKhatianTypeId, request.TransferedDagNo);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
