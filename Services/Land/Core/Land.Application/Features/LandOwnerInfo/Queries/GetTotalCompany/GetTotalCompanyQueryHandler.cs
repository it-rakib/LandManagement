using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetTotalCompany
{
    public class GetTotalCompanyQueryHandler : IRequestHandler<GetTotalCompanyQuery, int>
    {
        private readonly IOwnerInfoRepository _ownerInfoRepository;

        public GetTotalCompanyQueryHandler(IOwnerInfoRepository ownerInfoRepository)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));
        }

        public Task<int> Handle(GetTotalCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _ownerInfoRepository.GetTotalCompany();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
