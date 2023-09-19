using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Commands.CreateUpdateCmnSubRegOffice
{
    public class CreateCmnSubRegOfficeCommandHandler : IRequestHandler<CreateCmnSubRegOfficeCommand, CreateCmnSubRegOfficeCommandResponse>
    {
        private readonly ICmnSubRegOfficeRepository _cmnSubRegOfficeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCmnSubRegOfficeCommandHandler> _logger;

        public CreateCmnSubRegOfficeCommandHandler(ICmnSubRegOfficeRepository cmnSubRegOfficeRepository, IMapper mapper, ILogger<CreateCmnSubRegOfficeCommandHandler> logger)
        {
            _cmnSubRegOfficeRepository = cmnSubRegOfficeRepository ?? throw new ArgumentNullException(nameof(cmnSubRegOfficeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateCmnSubRegOfficeCommandResponse> Handle(CreateCmnSubRegOfficeCommand request, CancellationToken cancellationToken)
        {
            var subRegOfcCommandResponse = new CreateCmnSubRegOfficeCommandResponse();

            try
            {
                var validator = new CreateCmnSubRegOfficeCommandValidator(_cmnSubRegOfficeRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    subRegOfcCommandResponse.Success = false;
                    subRegOfcCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        subRegOfcCommandResponse.Message = subRegOfcCommandResponse.Message + "  " + error.ErrorMessage;
                        subRegOfcCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(subRegOfcCommandResponse.Message);
                    }
                }
                if (subRegOfcCommandResponse.Success)
                {
                    var subRegOffice = new CmnSubRegOffice()
                    {
                        SubRegOfficeId = request.SubRegOfficeId,
                        SubRegOfficeName = request.SubRegOfficeName,
                        UpozilaId = request.UpozilaId,
                        IsActive = request.IsActive,
                    };
                    if (subRegOffice.SubRegOfficeId == Guid.Empty)
                    {
                        subRegOffice = await _cmnSubRegOfficeRepository.AddAsync(subRegOffice);
                        subRegOfcCommandResponse.Message = subRegOffice.SubRegOfficeName + " Saved Successfully";
                        _logger.LogInformation($"{subRegOfcCommandResponse.Message = subRegOffice.SubRegOfficeName + " is Successfully Created"}");
                    }
                    else if(subRegOffice.IsActive == false)
                    {
                        subRegOffice = await _cmnSubRegOfficeRepository.Update(subRegOffice);
                        subRegOfcCommandResponse.Message = subRegOffice.SubRegOfficeName + " Deleted Successfully !";
                    }
                    else
                    {
                        subRegOffice = await _cmnSubRegOfficeRepository.Update(subRegOffice);
                        subRegOfcCommandResponse.Message = subRegOffice.SubRegOfficeName + " Updated Successfully";
                    }
                    subRegOfcCommandResponse.SubRegOfficeDto = _mapper.Map<CreateCmnSubRegOfficeDto>(subRegOffice);
                }
            }
            catch (Exception ex)
            {

                subRegOfcCommandResponse.Success = false;
                subRegOfcCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return subRegOfcCommandResponse;
        }
    }
}
