using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId
{
    public class GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoIdHandler
        : IRequestHandler<GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery, decimal>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoIdHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<decimal> Handle(GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId(request.SaleLandMasterId, request.SaleKhatianTypeId, request.SaleOwnerInfoId);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
