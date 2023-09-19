using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllUpozilaByDistrictIdList
{
    public class GetAllUpozilaByDistrictIdListQueryHandler : IRequestHandler<GetAllUpozilaByDistrictIdListQuery, List<GetAllUpozilaByDistrictIdListVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllUpozilaByDistrictIdListQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllUpozilaByDistrictIdListVm>> Handle(GetAllUpozilaByDistrictIdListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllUpozilaByDistrictId(request.DistrictId);
                var allUpozilaByDistrictId = _mapper.Map<List<GetAllUpozilaByDistrictIdListVm>>(data);
                return allUpozilaByDistrictId;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
