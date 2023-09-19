using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandSaleDetailByLandMasterId
{
    public class GetAllPlotWiseLandSaleDetailByLandMasterIdQueryHandler
        : IRequestHandler<GetAllPlotWiseLandSaleDetailByLandMasterIdQuery, List<PlotWiseLandSaleDetailByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllPlotWiseLandSaleDetailByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PlotWiseLandSaleDetailByLandMasterIdVm>> Handle(GetAllPlotWiseLandSaleDetailByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllPlotWiseLandSaleDetailByLandMasterId(request.LandMasterId);
                var plotWiseLandSaleDetails = _mapper.Map<List<PlotWiseLandSaleDetailByLandMasterIdVm>>(data);
                return plotWiseLandSaleDetails;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
