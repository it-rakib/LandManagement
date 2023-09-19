using System;
using System.Threading;
using System.Threading.Tasks;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalDeed
{
    public class GetTotalDeedQueryHandler : IRequestHandler<GetTotalDeedQuery, int>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalDeedQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<int> Handle(GetTotalDeedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalDeed();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
