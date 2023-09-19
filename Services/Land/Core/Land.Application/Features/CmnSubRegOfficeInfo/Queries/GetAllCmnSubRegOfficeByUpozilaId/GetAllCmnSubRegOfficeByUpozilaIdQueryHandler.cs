using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId
{
    public class GetAllCmnSubRegOfficeByUpozilaIdQueryHandler : IRequestHandler<GetAllCmnSubRegOfficeByUpozilaIdQuery, List<CmnSubRegOfficeByUpozilaIdVM>>
    {
        private readonly ICmnSubRegOfficeRepository _cmnSubRegOfficeRepository;
        private readonly IMapper _mapper;

        public GetAllCmnSubRegOfficeByUpozilaIdQueryHandler(ICmnSubRegOfficeRepository cmnSubRegOfficeRepository, IMapper mapper)
        {
            _cmnSubRegOfficeRepository = cmnSubRegOfficeRepository ?? throw new ArgumentNullException(nameof(cmnSubRegOfficeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnSubRegOfficeByUpozilaIdVM>> Handle(GetAllCmnSubRegOfficeByUpozilaIdQuery request, CancellationToken cancellationToken)
        {
            var subRegOffice = await _cmnSubRegOfficeRepository.GetSubRegOfficeByUpozilaIdAsync(request.UpozilaId);
            var subRegOfficelist = _mapper.Map<List<CmnSubRegOfficeByUpozilaIdVM>>(subRegOffice);
            return subRegOfficelist;
        }
    }
}
