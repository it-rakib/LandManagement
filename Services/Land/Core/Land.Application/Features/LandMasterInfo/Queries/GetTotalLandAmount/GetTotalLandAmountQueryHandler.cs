using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalLandAmount
{
    public class GetTotalLandAmountQueryHandler : IRequestHandler<GetTotalLandAmountQuery, decimal>
    {
        private  readonly ILandMasterRepository _landMasterRepository;

        public GetTotalLandAmountQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }


        public Task<decimal> Handle(GetTotalLandAmountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalLandAmount();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
