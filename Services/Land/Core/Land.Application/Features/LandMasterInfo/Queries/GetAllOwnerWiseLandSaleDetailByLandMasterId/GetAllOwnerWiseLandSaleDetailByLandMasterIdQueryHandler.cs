using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandSaleDetailByLandMasterId
{
    public class GetAllOwnerWiseLandSaleDetailByLandMasterIdQueryHandler
        : IRequestHandler<GetAllOwnerWiseLandSaleDetailByLandMasterIdQuery, List<OwnerWiseLandSaleDetailByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllOwnerWiseLandSaleDetailByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OwnerWiseLandSaleDetailByLandMasterIdVm>> Handle(GetAllOwnerWiseLandSaleDetailByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllOwnerWiseLandSaleDetailByLandMasterId(request.LandMasterId);
                var ownerWiseLandSaleDetails = _mapper.Map<List<OwnerWiseLandSaleDetailByLandMasterIdVm>>(data);
                return ownerWiseLandSaleDetails;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
