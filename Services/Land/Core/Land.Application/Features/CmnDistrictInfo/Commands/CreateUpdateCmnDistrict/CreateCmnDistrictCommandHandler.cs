using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Commands.CreateUpdateCmnDistrict
{
    public class CreateCmnDistrictCommandHandler : IRequestHandler<CreateCmnDistrictCommand, CreateCmnDistrictCommandResponse>
    {
        private readonly ICmnDistrictRepository _cmnDistrictRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCmnDistrictCommandHandler> _logger;

        public CreateCmnDistrictCommandHandler(ICmnDistrictRepository cmnDistrictRepository, IMapper mapper, ILogger<CreateCmnDistrictCommandHandler> logger)
        {
            _cmnDistrictRepository = cmnDistrictRepository ?? throw new ArgumentNullException(nameof(cmnDistrictRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateCmnDistrictCommandResponse> Handle(CreateCmnDistrictCommand request, CancellationToken cancellationToken)
        {
            var districtCommandResponse = new CreateCmnDistrictCommandResponse();

            try
            {
                var validator = new CreateCmnDistrictCommandValidator(_cmnDistrictRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    districtCommandResponse.Success = false;
                    districtCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        districtCommandResponse.Message = districtCommandResponse.Message + "  " + error.ErrorMessage;
                        districtCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(districtCommandResponse.Message);
                    }
                }
                if (districtCommandResponse.Success)
                {
                    var district = new CmnDistrict()
                    {
                        DistrictId = request.DistrictId,
                        DistrictName = request.DistrictName,
                        DivisionId = request.DivisionId
                    };
                    if (district.DistrictId == Guid.Empty)
                    {
                        district = await _cmnDistrictRepository.AddAsync(district);
                        districtCommandResponse.Message = district.DistrictName + " Saved Successfully";
                        _logger.LogInformation($"{districtCommandResponse.Message = district.DistrictName + " is Successfully Created"}");
                    }
                    else
                    {
                        district = await _cmnDistrictRepository.Update(district);
                        districtCommandResponse.Message = district.DistrictName + " Updated Successfully";
                    }
                    districtCommandResponse.DistrictDTO = _mapper.Map<CreateCmnDistrictDTO>(district);

                }
            }
            catch (Exception ex)
            {

                districtCommandResponse.Success = false;
                districtCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return districtCommandResponse;
        }
    }
}
