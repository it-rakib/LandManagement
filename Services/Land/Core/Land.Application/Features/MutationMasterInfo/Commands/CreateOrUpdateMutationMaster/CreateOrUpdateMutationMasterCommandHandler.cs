using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDocument;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Land.Application.Features.MutationMasterInfo.Commands.CreateOrUpdateMutationMaster
{
    public class CreateOrUpdateMutationMasterCommandHandler : IRequestHandler<CreateOrUpdateMutationMasterCommand, CreateOrUpdateMutationMasterCommandResponse>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;
        private readonly ICmnDocumentRepository _documentRepository;
        private readonly ILogger<CreateOrUpdateMutationMasterCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrUpdateMutationMasterCommandHandler(IMutationMasterRepository mutationMasterRepository, ICmnDocumentRepository documentRepository, ILogger<CreateOrUpdateMutationMasterCommandHandler> logger, IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateOrUpdateMutationMasterCommandResponse> Handle(CreateOrUpdateMutationMasterCommand request, CancellationToken cancellationToken)
        {
            var mutationMasterResponse = new CreateOrUpdateMutationMasterCommandResponse();
            try
            {
                var validator = new CreateOrUpdateMutationMasterCommandValidator(_mutationMasterRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    mutationMasterResponse.Success = false;
                    mutationMasterResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        mutationMasterResponse.Message = mutationMasterResponse.Message + Environment.NewLine + error.ErrorMessage;
                        mutationMasterResponse.ValidationErrors.Add(error.ErrorMessage);
                    }
                    _logger.LogError(mutationMasterResponse.Message);
                }
                if (mutationMasterResponse.Success)
                {
                    var mutationMaster = new MutationMaster
                    {
                        MutationMasterId = request.MutationMasterId,
                        DivisionId = request.DivisionId,
                        DistrictId = request.DistrictId,
                        UpozilaId = request.UpozilaId,
                        MouzaId = request.MouzaId,
                        MutationApplicationNo = request.MutationApplicationNo,
                        MutationApplicationDate = request.MutationApplicationDate,
                        CaseNo = request.CaseNo,
                        Dcrno = request.Dcrno,
                        MutationKhatianNo = request.MutationKhatianNo,
                        HoldingNo = request.HoldingNo,
                        Remarks = request.Remarks,
                        FileRemarks = request.FileRemarks,
                        IsDeleted = false,
                        IsRecorded = request.IsRecorded,

                        PlotWiseMutationDetails = request.PlotWiseMutationDetails != null ? setPlotWiseMutationDetail(request.PlotWiseMutationDetails) : new List<PlotWiseMutationDetail>(),
                        OwnerWiseMutationDetails = request.OwnerWiseMutationDetails != null ? setOwnerWiseMutationDetail(request.OwnerWiseMutationDetails) : new List<OwnerWiseMutationDetail>()
                    };

                    if (request.MutationMasterId == Guid.Empty)
                    {
                        mutationMaster.CreatedBy = request.CreatedBy;
                        mutationMaster.CreatedAt = DateTime.Now;
                        mutationMaster.CreatedPcIp = request.CreatedPcIp;
                        mutationMaster = await _mutationMasterRepository.AddAsync(mutationMaster);
                        saveDocument(request.DocumentVms, mutationMaster.MutationMasterId);
                        mutationMasterResponse.Message = "Holding No- " + mutationMaster.HoldingNo + " Saved Successfully!";
                    }
                    else
                    {
                        var mutationMasterById = await _mutationMasterRepository.GetMutationMasterById(request.MutationMasterId);
                        if (mutationMasterById != null && request.IsDeleted == false)
                        {
                            mutationMaster.CreatedBy = mutationMasterById.CreatedBy;
                            mutationMaster.CreatedAt = mutationMasterById.CreatedAt;
                            mutationMaster.CreatedPcIp = mutationMasterById.CreatedPcIp;
                            mutationMaster.UpdatedBy = request.UpdatedBy;
                            mutationMaster.UpdatedAt = DateTime.Now;
                            await _mutationMasterRepository.UpdateMutationMaster(mutationMaster);
                            saveDocument(request.DocumentVms, mutationMasterById.MutationMasterId);
                            mutationMasterResponse.Message = "Holding No- " + mutationMaster.HoldingNo + " Updated Successfully!";
                        }
                        else if(mutationMasterById != null && request.IsDeleted == true)
                        {
                            mutationMaster.IsDeleted = true;
                            await _mutationMasterRepository.UpdateMutationMaster(mutationMaster);
                            saveDocument(request.DocumentVms, mutationMasterById.MutationMasterId);
                            mutationMasterResponse.Message = "Holding No- " + mutationMaster.HoldingNo + " Deleted Successfully!";
                        }
                        else
                        {
                            mutationMasterResponse.Message = "Data Not Found!";
                        }
                    }
                    mutationMasterResponse.MutationMasterDto = _mapper.Map<CreateOrUpdateMutationMasterDto>(mutationMaster);
                }
                _logger.LogInformation(mutationMasterResponse.Message);
                return mutationMasterResponse;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public ICollection<PlotWiseMutationDetail> setPlotWiseMutationDetail(ICollection<PlotWiseMutationDetailCommand> plotWiseMutationDetailCommands)
        {
            List<PlotWiseMutationDetail> plotWiseMutationDetails = new();
            foreach (var cmd in plotWiseMutationDetailCommands)
            {
                PlotWiseMutationDetail plotWiseMutationDetail = new()
                {
                    PlotWiseMutationDetailId = cmd.PlotWiseMutationDetailId,
                    MutationMasterId = cmd.MutationMasterId,
                    LandMasterId = cmd.LandMasterId,
                    KhatianTypeId = cmd.KhatianTypeId,
                    KhatianNo = cmd.KhatianNo,
                    DagNo = cmd.DagNo,
                    PlotWiseMutationLandAmount = cmd.PlotWiseMutationLandAmount
                };
                plotWiseMutationDetails.Add(plotWiseMutationDetail);
            }
            return plotWiseMutationDetails;
        }

        public ICollection<OwnerWiseMutationDetail> setOwnerWiseMutationDetail(ICollection<OwnerWiseMutationDetailCommand> ownerWiseMutationDetailCommand)
        {
            List<OwnerWiseMutationDetail> ownerWiseMutationDetails = new();
            foreach (var cmd in ownerWiseMutationDetailCommand)
            {
                OwnerWiseMutationDetail ownerWiseMutationDetail = new()
                {
                    OwnerWiseMutationDetailId = cmd.OwnerWiseMutationDetailId,
                    MutationMasterId = cmd.MutationMasterId,
                    LandMasterId = cmd.LandMasterId,
                    KhatianTypeId = cmd.KhatianTypeId,
                    OwnerInfoId = cmd.OwnerInfoId,
                    OwnerLandAmount = cmd.OwnerLandAmount,
                    OwnerMutatedLandAmount = cmd.OwnerMutatedLandAmount
                };
                ownerWiseMutationDetails.Add(ownerWiseMutationDetail);
            }
            return ownerWiseMutationDetails;
        }

        private void saveDocument(ICollection<DocumentVM> requestDocumentVms, Guid mmid)
        {
            foreach (var item in requestDocumentVms)
            {
                item.ModuleMasterId = mmid;
                _documentRepository.AddRemoveDocument(item);
            }
        }
    }
}
