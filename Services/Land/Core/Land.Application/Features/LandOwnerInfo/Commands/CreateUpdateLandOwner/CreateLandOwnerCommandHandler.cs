using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Commands.CreateUpdateLandOwner
{
    public class CreateLandOwnerCommandHandler : IRequestHandler<CreateLandOwnerCommand, CreateLandOwnerCommandResponse>
    {
        private readonly IOwnerInfoRepository _ownerInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLandOwnerCommandHandler> _logger;

        public CreateLandOwnerCommandHandler(IOwnerInfoRepository ownerInfoRepository, IMapper mapper, ILogger<CreateLandOwnerCommandHandler> logger)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateLandOwnerCommandResponse> Handle(CreateLandOwnerCommand request, CancellationToken cancellationToken)
        {
            var landOwnerCommandResponse = new CreateLandOwnerCommandResponse();
            try
            {
                var validator = new CreateLandOwnerCommandValidator(_ownerInfoRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    landOwnerCommandResponse.Success = false;
                    landOwnerCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        landOwnerCommandResponse.Message = landOwnerCommandResponse.Message + "  " + error.ErrorMessage;
                        landOwnerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(landOwnerCommandResponse.Message);
                    }
                }
                if (landOwnerCommandResponse.Success)
                {
                    var ownerInfo = new OwnerInfo()
                    {
                        OwnerInfoId = request.OwnerInfoId,
                        OwnerInfoName = request.OwnerInfoName,
                        IsCompany = request.IsCompany,
                        IsActive = request.IsActive
                    };
                    if (ownerInfo.OwnerInfoId == Guid.Empty)
                    {
                        ownerInfo = await _ownerInfoRepository.AddAsync(ownerInfo);
                        landOwnerCommandResponse.Message = ownerInfo.OwnerInfoName + " Saved Successfully";
                        _logger.LogInformation($"{landOwnerCommandResponse.Message = ownerInfo.OwnerInfoName + " is Successfully Created"}");
                    }
                    else if(ownerInfo.IsActive == false)
                    {
                        ownerInfo = await _ownerInfoRepository.Update(ownerInfo);
                        landOwnerCommandResponse.Message = ownerInfo.OwnerInfoName + " Deleted Successfully !";
                    }
                    else
                    {
                        ownerInfo = await _ownerInfoRepository.Update(ownerInfo);
                        landOwnerCommandResponse.Message = ownerInfo.OwnerInfoName + " Updated Successfully";
                    }
                    landOwnerCommandResponse.LandOwnerDto = _mapper.Map<CreateLandOwnerDto>(ownerInfo);

                }
            }
            catch (Exception ex)
            {
                landOwnerCommandResponse.Success = false;
                landOwnerCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return landOwnerCommandResponse;
        }
    }
}
