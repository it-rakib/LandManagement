using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandOwnerListByLandMasterId
{
    public class GetAllLandOwnerListByLandMasterIdQueryHandler : IRequestHandler<GetAllLandOwnerListByLandMasterIdQuery, List<LandOwnerListByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandOwnerListByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandOwnerListByLandMasterIdVm>> Handle(GetAllLandOwnerListByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _landMasterRepository.GetAllLandOwnerListByLandMasterId(request.LandMasterId);
            var landOwnerDetails = _mapper.Map<List<LandOwnerListByLandMasterIdVm>>(data);
            return landOwnerDetails;
        }
    }
}
