using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId
{
    public class GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoIdQueryHandler
        : IRequestHandler<GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery, decimal>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoIdQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<decimal> Handle(GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId(request.TransferedLandMasterId, request.TransferedKhatianTypeId, request.TransferedOwnerInfoId);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
