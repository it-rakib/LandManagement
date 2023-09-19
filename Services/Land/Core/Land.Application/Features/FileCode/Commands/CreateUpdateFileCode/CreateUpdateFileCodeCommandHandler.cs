using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileCode.Commands.CreateUpdateFileCode
{
    public class CreateUpdateFileCodeCommandHandler :IRequestHandler<CreateUpdateFileCodeCommand,CreateUpdateFileCodeCommandResponse>
    {
        private readonly IFileCodeRepository _fileCodeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUpdateFileCodeCommandHandler> _logger;

        public CreateUpdateFileCodeCommandHandler(IFileCodeRepository fileCodeRepository, IMapper mapper, ILogger<CreateUpdateFileCodeCommandHandler> logger)
        {
            _fileCodeRepository = fileCodeRepository ?? throw new ArgumentNullException(nameof(fileCodeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateUpdateFileCodeCommandResponse> Handle(CreateUpdateFileCodeCommand request, CancellationToken cancellationToken)
        {
            var fileCommandResponse = new CreateUpdateFileCodeCommandResponse();
            try
            {
                var validator = new CreateUpdateFileCodeCommandValidator(_fileCodeRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    fileCommandResponse.Success = false;
                    fileCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        fileCommandResponse.Message = fileCommandResponse.Message + "  " + error.ErrorMessage;
                        fileCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(fileCommandResponse.Message);
                    }
                }
                if (fileCommandResponse.Success)
                {
                    var fileCode = new FileCodeInfo()
                    {
                        FileCodeInfoId = request.FileCodeInfoId,
                        FileCodeInfoName = request.FileCodeInfoName,
                        FileCodeInfoFullName = request.FileCodeInfoFullName,
                        IsActive = request.IsActive,
                    };
                    if (fileCode.FileCodeInfoId == Guid.Empty)
                    {
                        fileCode = await _fileCodeRepository.AddAsync(fileCode);
                        fileCommandResponse.Message = fileCode.FileCodeInfoName + " Saved Successfully";
                        _logger.LogInformation($"{fileCommandResponse.Message = fileCode.FileCodeInfoName + " is Successfully Created !"}");
                    }

                    else if(fileCode.IsActive == false)
                    {
                        fileCode = await _fileCodeRepository.Update(fileCode);
                        fileCommandResponse.Message = fileCode.FileCodeInfoName + " is Deleted !";
                    }                     
                    else
                    {
                        fileCode = await _fileCodeRepository.Update(fileCode);
                        fileCommandResponse.Message = fileCode.FileCodeInfoName + " Updated Successfully !";
                    }
                    fileCommandResponse.FileCodeDTO = _mapper.Map<CreateUpdateFileCodeDTO>(fileCode);
                }
            }
            catch (Exception ex)
            {

                fileCommandResponse.Success = false;
                fileCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return fileCommandResponse;
        }
    }
}
