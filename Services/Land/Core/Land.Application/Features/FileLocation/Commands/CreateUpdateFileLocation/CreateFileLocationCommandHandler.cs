using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Land.Domain.Models;

namespace Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation
{
    public class CreateFileLocationCommandHandler : IRequestHandler<CreateFileLocationCommand, CreateFileLocationCommandResponse>
    {
        private readonly IFileLocationRepository _fileLocationRepository;
        private readonly ILogger<CreateFileLocationCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateFileLocationCommandHandler(IFileLocationRepository fileLocationRepository, ILogger<CreateFileLocationCommandHandler> logger, IMapper mapper)
        {
            _fileLocationRepository = fileLocationRepository ?? throw new ArgumentNullException(nameof(fileLocationRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateFileLocationCommandResponse> Handle(CreateFileLocationCommand request, CancellationToken cancellationToken)
        {
            var fileLocationResponse = new CreateFileLocationCommandResponse();
            try
            {
                var validator = new CreateFileLocationCommandValidator(_fileLocationRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    fileLocationResponse.Success = false;
                    fileLocationResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        fileLocationResponse.Message = fileLocationResponse.Message + Environment.NewLine + error.ErrorMessage;
                        fileLocationResponse.ValidationErrors.Add(error.ErrorMessage);
                    }
                    _logger.LogError(fileLocationResponse.Message);
                }
                if (fileLocationResponse.Success)
                {
                    var fileLocation = new FileLocationMaster()
                    {
                        FileLocationMasterId = request.FileLocationMasterId,
                        FileCodeInfoId = request.FileCodeInfoId,
                        FileNoInfoId = request.FileNoInfoId,
                        AlmirahNoInfoId = request.AlmirahNoInfoId,
                        RackNoInfoId = request.RackNoInfoId,
                        Remarks = request.Remarks,
                        IsDeleted = false,

                        FileLocationDetails = request.FileLocationDetails != null ? setFileLocationDetail(request.FileLocationDetails) : new List<FileLocationDetail>(),
                    };

                    if (request.FileLocationMasterId == Guid.Empty)
                    {
                        fileLocation.CreatedBy = request.CreatedBy;
                        fileLocation.CreatedAt = DateTime.Now;
                        fileLocation.CreatedPcIp = request.CreatedPcIp;
                        fileLocation = await _fileLocationRepository.AddAsync(fileLocation);
                        fileLocationResponse.Message = "Saved Successfully!";
                    }
                    else
                    {
                        var fileLocationById = await _fileLocationRepository.GetFileLocationMasterById(request.FileLocationMasterId);
                        if (fileLocationById != null && request.IsDeleted == false)
                        {
                            fileLocation.CreatedBy = fileLocationById.CreatedBy;
                            fileLocation.CreatedAt = fileLocationById.CreatedAt;
                            fileLocation.CreatedPcIp = fileLocationById.CreatedPcIp;
                            fileLocation.UpdatedBy = request.UpdatedBy;
                            fileLocation.UpdatedAt = DateTime.Now;
                            await _fileLocationRepository.UpdateFileLocationMaster(fileLocation);
                            fileLocationResponse.Message = "Updated Successfully!";
                        }
                        else if (fileLocationById != null && request.IsDeleted == true)
                        {
                            fileLocation.IsDeleted = true;
                            await _fileLocationRepository.UpdateFileLocationMaster(fileLocation);
                            fileLocationResponse.Message = "Deleted Successfully!";
                        }
                        else
                        {
                            fileLocationResponse.Message = "Data Not Found!";
                        }
                    }
                    fileLocationResponse.FileLocationDto = _mapper.Map<CreateFileLocationDto>(fileLocation);
                }
                _logger.LogInformation(fileLocationResponse.Message);
                return fileLocationResponse;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        public ICollection<FileLocationDetail> setFileLocationDetail(ICollection<FileLocationDetailCommand> fileLocationDetailCommand)
        {
            List<FileLocationDetail> fileLocationDetails = new();
            foreach (var cmd in fileLocationDetailCommand)
            {
                FileLocationDetail fileLocationDetail = new()
                {
                    FileLocationDetailId = cmd.FileLocationDetailId,
                    FileLocationMasterId = cmd.FileLocationMasterId,
                    LandMasterId = cmd.LandMasterId
                };
                fileLocationDetails.Add(fileLocationDetail);
            }
            return fileLocationDetails;
        }
    }
}
