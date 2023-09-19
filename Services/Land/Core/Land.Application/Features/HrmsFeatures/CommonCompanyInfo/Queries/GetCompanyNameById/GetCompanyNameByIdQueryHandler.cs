using AutoMapper;
using MediatR;
using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetCompanyNameById
{
    public class GetCompanyNameByIdQueryHandler : IRequestHandler<GetCompanyNameByIdQuery, CompanyNameByIdVm>
    {
        private readonly ICommonCompanyRepository _commonCompanyRepository;
        private readonly IMapper _mapper;

        public GetCompanyNameByIdQueryHandler(ICommonCompanyRepository commonCompanyRepository, IMapper mapper)
        {
            _commonCompanyRepository = commonCompanyRepository ?? throw new ArgumentNullException(nameof(commonCompanyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CompanyNameByIdVm> Handle(GetCompanyNameByIdQuery request, CancellationToken cancellationToken)
        {
            var sourceList = await _commonCompanyRepository.GetCompanyNameById(request.Id);
            return _mapper.Map<CompanyNameByIdVm>(sourceList);
        }
    }
}
