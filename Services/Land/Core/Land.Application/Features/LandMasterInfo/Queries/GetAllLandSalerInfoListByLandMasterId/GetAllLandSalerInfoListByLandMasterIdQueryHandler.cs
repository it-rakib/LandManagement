using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSalerInfoListByLandMasterId
{
    public class GetAllLandSalerInfoListByLandMasterIdQueryHandler : IRequestHandler<GetAllLandSalerInfoListByLandMasterIdQuery, List<LandSalerInfoListByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandSalerInfoListByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandSalerInfoListByLandMasterIdVm>> Handle(GetAllLandSalerInfoListByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _landMasterRepository.GetAllLandSalerInfoListByLandMasterId(request.LandMasterId);
            var landSalerInfo = _mapper.Map<List<LandSalerInfoListByLandMasterIdVm>>(data);
            return landSalerInfo;
        }
    }
}
