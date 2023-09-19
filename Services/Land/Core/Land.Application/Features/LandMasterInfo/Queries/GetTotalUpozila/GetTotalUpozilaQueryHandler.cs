using System;
using System.Threading;
using System.Threading.Tasks;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalUpozila
{
    public class GetTotalUpozilaQueryHandler : IRequestHandler<GetTotalUpozilaQuery, int>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalUpozilaQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }


        public Task<int> Handle(GetTotalUpozilaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalUpozila();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
