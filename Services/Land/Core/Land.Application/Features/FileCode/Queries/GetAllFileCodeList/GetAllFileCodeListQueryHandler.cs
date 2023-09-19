using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileCode.Queries.GetAllFileCodeList
{
    public class GetAllFileCodeListQueryHandler : IRequestHandler<GetAllFileCodeListQuery, List<FileCodeListVm>>
    {
        private readonly IAsyncRepository<FileCodeInfo> _fileCodeRepository;
        private readonly IMapper _mapper;

        public GetAllFileCodeListQueryHandler(IAsyncRepository<FileCodeInfo> fileCodeRepository, IMapper mapper)
        {
            _fileCodeRepository = fileCodeRepository ?? throw new ArgumentNullException(nameof(fileCodeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<FileCodeListVm>> Handle(GetAllFileCodeListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = (await _fileCodeRepository.GetAllAsync()).OrderBy(x => x.FileCodeInfoName);
                return _mapper.Map<List<FileCodeListVm>>(list);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
