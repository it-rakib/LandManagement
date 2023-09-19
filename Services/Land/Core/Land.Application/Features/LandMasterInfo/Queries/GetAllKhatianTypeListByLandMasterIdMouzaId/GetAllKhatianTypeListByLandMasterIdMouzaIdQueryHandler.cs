using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterIdMouzaId
{
    public class GetAllKhatianTypeListByLandMasterIdMouzaIdQueryHandler : IRequestHandler<GetAllKhatianTypeListByLandMasterIdMouzaIdQuery, List<KhatianTypeListByLandMasterIdMouzaIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllKhatianTypeListByLandMasterIdMouzaIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<KhatianTypeListByLandMasterIdMouzaIdVm>> Handle(GetAllKhatianTypeListByLandMasterIdMouzaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllKhatianTypeListByLandMasterIdMouzaId(request.LandMasterId, request.MouzaId);
                var khatianTypes = _mapper.Map<List<KhatianTypeListByLandMasterIdMouzaIdVm>>(data);
                return khatianTypes;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
