using AutoMapper;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId
{
    public class GetAllLandSummaryByLandMasterIdQueryHandler : IRequestHandler<GetAllLandSummaryByLandMasterIdQuery, List<LandSummaryByLandMasterIdVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryByLandMasterIdQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository, IMapper mapper)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandSummaryByLandMasterIdVm>> Handle(GetAllLandSummaryByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandSummaryByLandMasterId(request.LandMasterId);
                var result = _mapper.Map<List<LandSummaryByLandMasterIdVm>>(list);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
