using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId
{
    public class GetAllFileLocationDetailListByFileLocationMasterIdQueryHandler
        : IRequestHandler<GetAllFileLocationDetailListByFileLocationMasterIdQuery, List<FileLocationDetailListByFileLocationMasterIdVm>>
    {
        private readonly IFileLocationRepository _fileLocationRepository;
        private readonly IMapper _mapper;

        public GetAllFileLocationDetailListByFileLocationMasterIdQueryHandler(IFileLocationRepository fileLocationRepository, IMapper mapper)
        {
            _fileLocationRepository = fileLocationRepository ?? throw new ArgumentNullException(nameof(fileLocationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<FileLocationDetailListByFileLocationMasterIdVm>> Handle(GetAllFileLocationDetailListByFileLocationMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _fileLocationRepository.GetAllFileLocationDetailListByFileLocationMasterId(request.FileLocationMasterId);
                var locationDetails = _mapper.Map<List<FileLocationDetailListByFileLocationMasterIdVm>>(data);
                return locationDetails;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
