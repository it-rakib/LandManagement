using AutoMapper;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId
{
    public class GetAllLandSummaryOwnerUpozilaListByOwnerInfoIdQueryHandler : IRequestHandler<GetAllLandSummaryOwnerUpozilaListByOwnerInfoIdQuery, List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;
        private readonly IMapper _mapper;

        public GetAllLandSummaryOwnerUpozilaListByOwnerInfoIdQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository, IMapper mapper)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>> Handle(GetAllLandSummaryOwnerUpozilaListByOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId(request.OwnerInfoId);
                var ownerUpozilaList = _mapper.Map<List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>>(list);
                return ownerUpozilaList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
