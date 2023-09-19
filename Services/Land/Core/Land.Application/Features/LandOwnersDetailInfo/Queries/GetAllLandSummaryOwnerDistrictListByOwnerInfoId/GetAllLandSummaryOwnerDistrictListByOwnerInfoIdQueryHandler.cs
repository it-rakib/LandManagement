using AutoMapper;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId
{
    public class GetAllLandSummaryOwnerDistrictListByOwnerInfoIdQueryHandler : IRequestHandler<GetAllLandSummaryOwnerDistrictListByOwnerInfoIdQuery, List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryOwnerDistrictListByOwnerInfoIdQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository, IMapper mapper)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>> Handle(GetAllLandSummaryOwnerDistrictListByOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandSummaryOwnerDistrictListByOwnerInfoId(request.OwnerInfoId);
                var ownerDistrictList = _mapper.Map<List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>>(list);
                return ownerDistrictList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
