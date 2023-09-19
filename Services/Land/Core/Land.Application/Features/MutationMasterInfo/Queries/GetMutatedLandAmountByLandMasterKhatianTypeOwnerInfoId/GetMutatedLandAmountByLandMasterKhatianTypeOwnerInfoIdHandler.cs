using System;
using System.Threading;
using System.Threading.Tasks;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId
{
    public class MutatedLandAmountByLandMasterKhatianTypeOwnerInfoIdHandler
        : IRequestHandler<GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery, decimal>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public MutatedLandAmountByLandMasterKhatianTypeOwnerInfoIdHandler(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
        }

        public Task<decimal> Handle(GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mutationMasterRepository.GetTotalOwnerWiseMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId(request.LandMasterId, request.KhatianTypeId, request.OwnerInfoId);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
