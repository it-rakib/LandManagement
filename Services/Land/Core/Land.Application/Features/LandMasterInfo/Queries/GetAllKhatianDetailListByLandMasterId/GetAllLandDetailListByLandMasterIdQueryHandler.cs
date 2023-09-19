using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandDetailListByLandMasterId
{
    public class GetAllLandDetailListByLandMasterIdQueryHandler : IRequestHandler<GetAllKhatianDetailListByLandMasterIdQuery, List<KhatianDetailListByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandDetailListByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<KhatianDetailListByLandMasterIdVm>> Handle(GetAllKhatianDetailListByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _landMasterRepository.GetAllKhatianDetailListByLandMasterId(request.LandMasterId);
            var khatianDetails = _mapper.Map<List<KhatianDetailListByLandMasterIdVm>>(data);
            return khatianDetails;
        }
    }
}
