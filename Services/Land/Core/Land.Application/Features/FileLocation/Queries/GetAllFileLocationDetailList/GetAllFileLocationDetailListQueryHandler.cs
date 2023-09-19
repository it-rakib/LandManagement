using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList
{
    public class GetAllFileLocationDetailListQueryHandler : IRequestHandler<GetAllFileLocationDetailListQuery, List<FileLocationDetailListVm>>
    {
        private readonly IFileLocationRepository _fileLocationRepository;
        private readonly IMapper _mapper;

        public GetAllFileLocationDetailListQueryHandler(IFileLocationRepository fileLocationRepository, IMapper mapper)
        {
            _fileLocationRepository = fileLocationRepository ?? throw new ArgumentNullException(nameof(fileLocationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<FileLocationDetailListVm>> Handle(GetAllFileLocationDetailListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _fileLocationRepository.GetAllFileLocationDetailList();
                var locationDetails = _mapper.Map<List<FileLocationDetailListVm>>(data);
                return locationDetails;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
