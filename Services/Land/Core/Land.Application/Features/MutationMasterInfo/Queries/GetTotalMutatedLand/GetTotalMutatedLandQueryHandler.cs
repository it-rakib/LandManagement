using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetTotalMutatedLand
{
    public class GetTotalMutatedLandQueryHandler : IRequestHandler<GetTotalMutatedLandQuery, decimal>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public GetTotalMutatedLandQueryHandler(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
        }

        public Task<decimal> Handle(GetTotalMutatedLandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mutationMasterRepository.GetTotalMutatedLand();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
