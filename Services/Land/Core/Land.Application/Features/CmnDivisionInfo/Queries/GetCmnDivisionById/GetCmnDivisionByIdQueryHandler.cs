using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDivisionInfo.Queries.GetCmnDivisionById
{
    public class GetCmnDivisionByIdQueryHandler : IRequestHandler<GetCmnDivisionByIdQuery, CmnDivisionByIdVM>
    {
        private readonly IAsyncRepository<CmnDivision> _cmnDivisionRepository;
        private readonly IMapper _mapper;

        public GetCmnDivisionByIdQueryHandler(IAsyncRepository<CmnDivision> cmnDivisionRepository, IMapper mapper)
        {
            _cmnDivisionRepository = cmnDivisionRepository ?? throw new ArgumentNullException(nameof(cmnDivisionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CmnDivisionByIdVM> Handle(GetCmnDivisionByIdQuery request, CancellationToken cancellationToken)
        {
            var division = await _cmnDivisionRepository.GetByIdAsync(request.DivisionId);
            var singleDivision = _mapper.Map<CmnDivisionByIdVM>(division);
            return singleDivision;
        }
    }
}
