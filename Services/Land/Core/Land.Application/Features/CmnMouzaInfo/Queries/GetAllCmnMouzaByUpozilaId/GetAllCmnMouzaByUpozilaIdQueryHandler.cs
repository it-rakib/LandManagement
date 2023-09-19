using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId
{
    public class GetAllCmnMouzaByUpozilaIdQueryHandler : IRequestHandler<GetAllCmnMouzaByUpozilaIdQuery, List<CmnMouzaByUpozilaIdVM>>
    {
        private readonly ICmnMouzaRepository _cmnMouzaRepository;
        private readonly IMapper _mapper;

        public GetAllCmnMouzaByUpozilaIdQueryHandler(ICmnMouzaRepository cmnMouzaRepository, IMapper mapper)
        {
            _cmnMouzaRepository = cmnMouzaRepository ?? throw new ArgumentNullException(nameof(cmnMouzaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnMouzaByUpozilaIdVM>> Handle(GetAllCmnMouzaByUpozilaIdQuery request, CancellationToken cancellationToken)
        {
            var mouza = await _cmnMouzaRepository.GetMouzaByUpozilaIdAsync(request.UpozilaId);
            var mouzaList = _mapper.Map<List<CmnMouzaByUpozilaIdVM>>(mouza);
            return mouzaList;
        }
    }
}
