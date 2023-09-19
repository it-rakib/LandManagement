using AutoMapper;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerMouzaListByOwnerInfoId
{
    public class GetAllLandSummaryOwnerMouzaListByOwnerInfoIdQueryHandler : IRequestHandler<GetAllLandSummaryOwnerMouzaListByOwnerInfoIdQuery, List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryOwnerMouzaListByOwnerInfoIdQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository, IMapper mapper)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>> Handle(GetAllLandSummaryOwnerMouzaListByOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandSummaryOwnerMouzaListByOwnerInfoId(request.OwnerInfoId);
                var ownerMouzaList = _mapper.Map<List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>>(list);
                return ownerMouzaList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
