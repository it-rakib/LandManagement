using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId
{
    public class GetFileNoListByFileCodeIdQueryHandler : IRequestHandler<GetFileNoListByFileCodeIdQuery, List<FileNoListByFileCodeIdVm>>
    {
        private readonly IFileNoRepository _fileNoRepository;
        private readonly IMapper _mapper;

        public GetFileNoListByFileCodeIdQueryHandler(IFileNoRepository fileNoRepository, IMapper mapper)
        {
            _fileNoRepository = fileNoRepository ?? throw new ArgumentNullException(nameof(fileNoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<FileNoListByFileCodeIdVm>> Handle(GetFileNoListByFileCodeIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fileNoList = await _fileNoRepository.GetFileNoListByFileCodeId(request.FileCodeInfoId);
                //var result = _mapper.Map<FileNoListByFileCodeIdVm>(fileNoList);
                //return await Task.FromResult(result);
                return fileNoList;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
