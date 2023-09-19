using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System.Linq;

namespace Land.Application.Features.CmnBanglaYearInfo.Queries.GetAllCmnBanglaYearList
{
    public class GetAllCmnBanglaYearListQueryHandler : IRequestHandler<GetAllCmnBanglaYearListQuery, List<CmnBanglaYearVm>>
    {
        private readonly IAsyncRepository<CmnBanglaYear> _cmnBanglaYearRepository;
        private readonly IMapper _mapper;

        public GetAllCmnBanglaYearListQueryHandler(IAsyncRepository<CmnBanglaYear> cmnBanglaYearRepository,
            IMapper mapper)
        {
            _cmnBanglaYearRepository = cmnBanglaYearRepository ?? throw new ArgumentNullException(nameof(cmnBanglaYearRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnBanglaYearVm>> Handle(GetAllCmnBanglaYearListQuery request, CancellationToken cancellationToken)
        {
            var list = (await _cmnBanglaYearRepository.GetAllAsync()).OrderBy(x => x.BanglaYearName);
            return _mapper.Map<List<CmnBanglaYearVm>>(list);
        }
    }
}
