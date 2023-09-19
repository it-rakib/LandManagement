using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDocument.Commands.CreateUpdateDocumentCommand
{
    public class CreateOrUpdateCmnDocumentCommandHandler : IRequestHandler<CreateOrUpdateCmnDocumentCommand, CreateOrUpdateCmnDocumentCommandResponse>
    {
        private readonly ICmnDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrUpdateCmnDocumentCommandHandler> _logger;

        public CreateOrUpdateCmnDocumentCommandHandler(ICmnDocumentRepository documentRepository, IMapper mapper, ILogger<CreateOrUpdateCmnDocumentCommandHandler> logger)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateOrUpdateCmnDocumentCommandResponse> Handle(CreateOrUpdateCmnDocumentCommand request, CancellationToken cancellationToken)
        {
            var documentCommandResponse = new CreateOrUpdateCmnDocumentCommandResponse();
            try
            {
                var validator = new CreateOrUpdateCmnDocumentCommandValidator(_documentRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    documentCommandResponse.Success = false;
                    documentCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        documentCommandResponse.Message = documentCommandResponse.Message + "  " + error.ErrorMessage;
                        documentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(documentCommandResponse.Message);
                    }
                }
                if (documentCommandResponse.Success)
                {
                    var documentFile = new CmnDocumentFile()
                    {
                        // DocumentId = request.DocumentId,
                        FileName = request.FileName,
                        ModuleName = request.ModuleName,
                        ModuleMasterId = request.ModuleMasterId,
                        FileSize = request.FileSize,
                        FileExtension = request.FileExtension,
                        FileUniqueName = request.FileUniqueName
                    };
                    if (request.ActionType == "Save")
                    {
                        documentFile = await _documentRepository.AddAsync(documentFile);
                        documentCommandResponse.Message = request.FileName + " Saved Successfully";
                        _logger.LogInformation($"{documentCommandResponse.Message = request.FileName + " is Successfully Created"}");
                    }
                    else
                    {
                        var model = _documentRepository.GetDocumentFileInfo(documentFile.FileUniqueName);
                        await _documentRepository.DeleteAsync(model);
                        documentCommandResponse.Message = documentFile.FileName + " Removed Successfully";
                    }
                    //  documentCommandResponse.cmnDto = _mapper.Map<CreateOrUpdateCmnDocumentDto>(documentFile);
                }
            }
            catch (Exception ex)
            {

                documentCommandResponse.Success = false;
                documentCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return documentCommandResponse;
        }
    }
}
