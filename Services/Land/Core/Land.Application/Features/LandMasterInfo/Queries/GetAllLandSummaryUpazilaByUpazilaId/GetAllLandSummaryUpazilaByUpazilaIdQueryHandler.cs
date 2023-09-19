using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpazilaByUpazilaId
{
    public class GetAllLandSummaryUpazilaByUpazilaIdQueryHandler
        : IRequestHandler<GetAllLandSummaryUpazilaByUpazilaIdQuery, LandSummaryUpazilaByUpazilaIdVm>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryUpazilaByUpazilaIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LandSummaryUpazilaByUpazilaIdVm> Handle(GetAllLandSummaryUpazilaByUpazilaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryUpazilaByUpazilaId(request.UpozilaId);
                return _mapper.Map<LandSummaryUpazilaByUpazilaIdVm>(list);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
