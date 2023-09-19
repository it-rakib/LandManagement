using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId
{
    public class GetAllLandOwnerTypeListByLandMasterIdQueryHandler : IRequestHandler<GetAllLandOwnerTypeListByLandMasterIdQuery, List<LandOwnerTypeListByLandMasterIdVm>>
    {
        private readonly ILandOwnerTypeRepository _landOwnerTypeRepository;
        private readonly IMapper _mapper;

        public GetAllLandOwnerTypeListByLandMasterIdQueryHandler(ILandOwnerTypeRepository landOwnerTypeRepository, IMapper mapper)
        {
            _landOwnerTypeRepository = landOwnerTypeRepository ?? throw new ArgumentNullException(nameof(landOwnerTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandOwnerTypeListByLandMasterIdVm>> Handle(GetAllLandOwnerTypeListByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _landOwnerTypeRepository.GetAllLandOwnerTypeListByLandMasterId(request.LandMasterId);
            var LandOwnerType = _mapper.Map<List<LandOwnerTypeListByLandMasterIdVm>>(data);
            return LandOwnerType;
        }
    }
}
