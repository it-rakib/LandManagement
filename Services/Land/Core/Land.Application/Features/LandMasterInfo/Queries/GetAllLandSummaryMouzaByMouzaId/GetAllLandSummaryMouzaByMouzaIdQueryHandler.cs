using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByMouzaId
{
    public class GetAllLandSummaryMouzaByMouzaIdQueryHandler : IRequestHandler<GetAllLandSummaryMouzaByMouzaIdQuery, LandSummaryMouzaByMouzaIdVm>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryMouzaByMouzaIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LandSummaryMouzaByMouzaIdVm> Handle(GetAllLandSummaryMouzaByMouzaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var landSummary = await _landMasterRepository.GetAllLandSummaryMouzaByMouzaId(request.MouzaId);
                var result = _mapper.Map<LandSummaryMouzaByMouzaIdVm>(landSummary);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
