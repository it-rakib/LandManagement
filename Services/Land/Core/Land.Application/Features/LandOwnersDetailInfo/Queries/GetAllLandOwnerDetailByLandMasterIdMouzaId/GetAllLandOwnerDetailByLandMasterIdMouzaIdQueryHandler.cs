using AutoMapper;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId
{
    public class GetAllLandOwnerDetailByLandMasterIdMouzaIdQueryHandler : IRequestHandler<GetAllLandOwnerDetailByLandMasterIdMouzaIdQuery, List<LandOwnerDetailByLandMasterIdMouzaIdVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;
        private readonly IMapper _mapper;

        public GetAllLandOwnerDetailByLandMasterIdMouzaIdQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository, IMapper mapper)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandOwnerDetailByLandMasterIdMouzaIdVm>> Handle(GetAllLandOwnerDetailByLandMasterIdMouzaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandOwnerDetailByLandMasterIdMouzaId(request.LandMasterId, request.MouzaId);
                var landOwnerDetail = _mapper.Map<List<LandOwnerDetailByLandMasterIdMouzaIdVm>>(list);
                return landOwnerDetail;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
