using System;
using System.Threading;
using System.Threading.Tasks;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalDistrict
{
    public class GetTotalDistrictQueryHandler : IRequestHandler<GetTotalDistrictQuery, int>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalDistrictQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<int> Handle(GetTotalDistrictQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalDistrict();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
