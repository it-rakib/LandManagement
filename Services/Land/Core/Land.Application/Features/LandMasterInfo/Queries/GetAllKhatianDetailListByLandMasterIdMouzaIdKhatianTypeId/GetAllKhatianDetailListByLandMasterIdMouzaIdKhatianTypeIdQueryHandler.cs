using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId
{
    public class GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdQueryHandler : IRequestHandler<GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdQuery, List<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>> Handle(GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _landMasterRepository.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId(request.LandMasterId, request.MouzaId, request.KhatianTypeId);
            var khatianDetails = _mapper.Map<List<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>>(data);
            return khatianDetails;
        }
    }
}
