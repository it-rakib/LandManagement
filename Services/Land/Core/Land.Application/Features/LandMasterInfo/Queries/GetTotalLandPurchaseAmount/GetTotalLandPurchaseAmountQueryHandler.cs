using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalLandPurchaseAmount
{
    public class GetTotalLandPurchaseAmountQueryHandler : IRequestHandler<GetTotalLandPurchaseAmountQuery, decimal>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalLandPurchaseAmountQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<decimal> Handle(GetTotalLandPurchaseAmountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _landMasterRepository.GetTotalLandPurchaseAmount();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
