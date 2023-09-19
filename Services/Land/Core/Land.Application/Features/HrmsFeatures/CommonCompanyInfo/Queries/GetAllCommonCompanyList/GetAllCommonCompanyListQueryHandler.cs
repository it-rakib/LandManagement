using AutoMapper;
using MediatR;
using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList
{
    public class GetAllCommonCompanyListQueryHandler : IRequestHandler<GetAllCommonCompanyListQuery, List<CommonCompanyListVm>>
    {
        private readonly ICommonCompanyRepository _commonCompanyRepository;
        private readonly IMapper _mapper;

        public GetAllCommonCompanyListQueryHandler(ICommonCompanyRepository commonCompanyRepository, IMapper mapper)
        {
            _commonCompanyRepository = commonCompanyRepository ?? throw new ArgumentNullException(nameof(commonCompanyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CommonCompanyListVm>> Handle(GetAllCommonCompanyListQuery request, CancellationToken cancellationToken)
        {
            return await _commonCompanyRepository.GetCompany();
        }
    }
}
