using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandTransferDetailByLandMasterId
{
    public class GetAllOwnerWiseLandTransferDetailByLandMasterIdQueryHandler
        : IRequestHandler<GetAllOwnerWiseLandTransferDetailByLandMasterIdQuery, List<OwnerWiseLandTransferDetailByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllOwnerWiseLandTransferDetailByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OwnerWiseLandTransferDetailByLandMasterIdVm>> Handle(GetAllOwnerWiseLandTransferDetailByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllOwnerWiseLandTransferDetailByLandMasterId(request.LandMasterId);
                var ownerWiseLandTransferDetails = _mapper.Map<List<OwnerWiseLandTransferDetailByLandMasterIdVm>>(data);
                return ownerWiseLandTransferDetails;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
