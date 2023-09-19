using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Land.Domain.Models;
using Land.Application.Features.CmnDocument;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax
{
    public class CreateOrUpdateLandDevelopmentTaxCommandHandler : IRequestHandler<CreateOrUpdateLandDevelopmentTaxCommand, CreateOrUpdateLandDevelopmentTaxCommandResponse>
    {
        private readonly ILandDevelopmentTaxRepository _developmentTaxRepository;
        private readonly ICmnDocumentRepository _documentRepository;
        private readonly ILogger<CreateOrUpdateLandDevelopmentTaxCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrUpdateLandDevelopmentTaxCommandHandler(ILandDevelopmentTaxRepository developmentTaxRepository, ICmnDocumentRepository documentRepository, ILogger<CreateOrUpdateLandDevelopmentTaxCommandHandler> logger, IMapper mapper)
        {
            _developmentTaxRepository = developmentTaxRepository ?? throw new ArgumentNullException(nameof(developmentTaxRepository));
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateOrUpdateLandDevelopmentTaxCommandResponse> Handle(CreateOrUpdateLandDevelopmentTaxCommand request, CancellationToken cancellationToken)
        {
            var landDevTaxResponse = new CreateOrUpdateLandDevelopmentTaxCommandResponse();
            try
            {
                var validator = new CreateOrUpdateLandDevelopmentTaxCommandValidator(_developmentTaxRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    landDevTaxResponse.Success = false;
                    landDevTaxResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        landDevTaxResponse.Message = landDevTaxResponse.Message + Environment.NewLine + error.ErrorMessage;
                        landDevTaxResponse.ValidationErrors.Add(error.ErrorMessage);
                    }
                    _logger.LogError(landDevTaxResponse.Message);
                }
                if (landDevTaxResponse.Success)
                {
                    var landDevTax = new LandDevelopmentTax()
                    {
                        LandDevelopmentTaxId = request.LandDevelopmentTaxId,
                        MutationMasterId = request.MutationMasterId,
                        DakhilaNo = request.DakhilaNo,
                        EntryDate = request.EntryDate,
                        FromDate = request.FromDate,
                        ToDate = request.ToDate,
                        TaxAmount = request.TaxAmount,
                        Remarks = request.Remarks,
                        FileRemarks = request.FileRemarks,
                        IsDeleted = false,
                    };

                    if (request.LandDevelopmentTaxId == Guid.Empty)
                    {
                        landDevTax.CreatedBy = request.CreatedBy;
                        landDevTax.CreatedAt = DateTime.Now;
                        landDevTax.CreatedPcIp = request.CreatedPcIp;
                        landDevTax = await _developmentTaxRepository.AddAsync(landDevTax);
                        saveDocument(request.DocumentVms, landDevTax.LandDevelopmentTaxId);
                        landDevTaxResponse.Message = "Saved Successfully!";
                    }
                    else
                    {
                        var landDevTaxById = await _developmentTaxRepository.GetLandDevelopmentTaxById(request.LandDevelopmentTaxId);
                        if (landDevTaxById != null && request.IsDeleted == false )
                        {
                            landDevTax.CreatedBy = landDevTaxById.CreatedBy;
                            landDevTax.CreatedAt = landDevTaxById.CreatedAt;
                            landDevTax.CreatedPcIp = landDevTaxById.CreatedPcIp;
                            landDevTax.UpdatedBy = request.UpdatedBy;
                            landDevTax.UpdatedAt = DateTime.Now;
                            await _developmentTaxRepository.Update(landDevTax);
                            saveDocument(request.DocumentVms, landDevTaxById.LandDevelopmentTaxId);
                            landDevTaxResponse.Message = "Updated Successfully!";
                        }
                        else if(landDevTaxById != null && request.IsDeleted == true)
                        {
                            landDevTax.IsDeleted = true;
                            await _developmentTaxRepository.Update(landDevTax);
                            saveDocument(request.DocumentVms, landDevTaxById.LandDevelopmentTaxId);
                            landDevTaxResponse.Message = "Deleted Successfully!";
                        }
                        else
                        {
                            landDevTaxResponse.Message = "Data Not Found!";
                        }
                    }
                    landDevTaxResponse.LandDevelopmentTaxDto = _mapper.Map<CreateOrUpdateLandDevelopmentTaxDto>(landDevTax);
                }
                _logger.LogInformation(landDevTaxResponse.Message);
                return landDevTaxResponse;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        private void saveDocument(ICollection<DocumentVM> requestDocumentVms, Guid ltid)
        {
            foreach (var item in requestDocumentVms)
            {
                item.ModuleMasterId = ltid;
                _documentRepository.AddRemoveDocument(item);
            }
        }
    }
}
