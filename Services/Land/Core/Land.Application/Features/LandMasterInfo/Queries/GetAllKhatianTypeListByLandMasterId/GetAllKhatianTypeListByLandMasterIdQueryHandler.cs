using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterId
{
    public class GetAllKhatianTypeListByLandMasterIdQueryHandler : IRequestHandler<GetAllKhatianTypeListByLandMasterIdQuery, List<KhatianTypeListByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllKhatianTypeListByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<KhatianTypeListByLandMasterIdVm>> Handle(GetAllKhatianTypeListByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllKhatianTypeListByLandMasterId(request.LandMasterId);
                var khatianTypes = _mapper.Map<List<KhatianTypeListByLandMasterIdVm>>(data);
                return khatianTypes;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
