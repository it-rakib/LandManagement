using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetTotalMutatedLandByLandMasterIdKhatianTypeId
{
    public class GetTotalMutatedLandByLandMasterIdKhatianTypeIdQueryHandler : IRequestHandler<GetTotalMutatedLandByLandMasterIdKhatianTypeIdQuery, decimal>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public GetTotalMutatedLandByLandMasterIdKhatianTypeIdQueryHandler(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
        }

        public Task<decimal> Handle(GetTotalMutatedLandByLandMasterIdKhatianTypeIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mutationMasterRepository.GetTotalMutatedLandByLandMasterIdKhatianTypeId(request.LandMasterId, request.KhatianTypeId);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
