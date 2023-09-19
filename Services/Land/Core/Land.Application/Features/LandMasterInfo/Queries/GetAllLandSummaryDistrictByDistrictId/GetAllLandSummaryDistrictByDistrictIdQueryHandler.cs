using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictByDistrictId
{
    public class GetAllLandSummaryDistrictByDistrictIdQueryHandler
        : IRequestHandler<GetAllLandSummaryDistrictByDistrictIdQuery, LandSummaryDistrictByDistrictIdVm>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryDistrictByDistrictIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LandSummaryDistrictByDistrictIdVm> Handle(GetAllLandSummaryDistrictByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var landSummary = await _landMasterRepository.GetAllLandSummaryDistrictByDistrictId(request.DistrictId);
                var result = _mapper.Map<LandSummaryDistrictByDistrictIdVm>(landSummary);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
