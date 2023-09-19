using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllBayaDeedDetailListByLandMasterId
{
    public class GetAllBayaDeedDetailListByLandMasterIdQueryHandler
        : IRequestHandler<GetAllBayaDeedDetailListByLandMasterIdQuery, List<BayaDeedDetailListByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllBayaDeedDetailListByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<BayaDeedDetailListByLandMasterIdVm>> Handle(GetAllBayaDeedDetailListByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllBayaDeedDetailListByLandMasterId(request.LandMasterId);
                var bayaDetails = _mapper.Map<List<BayaDeedDetailListByLandMasterIdVm>>(data);
                return bayaDetails;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
