using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetTotalPerson
{
    public class GetTotalPersonQueryHandler : IRequestHandler<GetTotalPersonQuery, int>
    {
        private readonly IOwnerInfoRepository _ownerInfoRepository;

        public GetTotalPersonQueryHandler(IOwnerInfoRepository ownerInfoRepository)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));
        }

        public Task<int> Handle(GetTotalPersonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _ownerInfoRepository.GetTotalPerson();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
