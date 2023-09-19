using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictList
{
    public class GetAllLandSummaryDistrictListQueryHandler : IRequestHandler<GetAllLandSummaryDistrictListQuery, List<GetAllLandSummaryDistrictListVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryDistrictListQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllLandSummaryDistrictListVm>> Handle(GetAllLandSummaryDistrictListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryDistrictList();
                return _mapper.Map<List<GetAllLandSummaryDistrictListVm>>(list);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
