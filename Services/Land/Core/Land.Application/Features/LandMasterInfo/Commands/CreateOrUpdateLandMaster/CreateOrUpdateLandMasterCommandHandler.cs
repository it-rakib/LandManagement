using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDocument;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster
{
    public class CreateOrUpdateLandMasterCommandHandler : IRequestHandler<CreateOrUpdateLandMasterCommand, CreateOrUpdateLandMasterCommandResponse>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly ICmnDocumentRepository _documentRepository;
        private readonly ILogger<CreateOrUpdateLandMasterCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrUpdateLandMasterCommandHandler(ICmnDocumentRepository documentRepository,ILandMasterRepository landMasterRepository, ILogger<CreateOrUpdateLandMasterCommandHandler> logger, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateOrUpdateLandMasterCommandResponse> Handle(CreateOrUpdateLandMasterCommand request, CancellationToken cancellationToken)
        {
            var landMasterResponse = new CreateOrUpdateLandMasterCommandResponse();
            try
            {
                var validator = new CreateOrUpdateLandMasterCommandValidator(_landMasterRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    landMasterResponse.Success = false;
                    landMasterResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        landMasterResponse.Message = landMasterResponse.Message + Environment.NewLine + error.ErrorMessage;
                        landMasterResponse.ValidationErrors.Add(error.ErrorMessage);
                    }
                    _logger.LogError(landMasterResponse.Message);
                }
                if (landMasterResponse.Success)
                {
                    var landMaster = new LandMaster
                    {
                        LandMasterId = request.LandMasterId,
                        DivisionId = request.DivisionId,
                        DistrictId = request.DistrictId,
                        UpozilaId = request.UpozilaId,
                        DeedNo = request.DeedNo,
                        EntryDate = DateTime.Parse(request.EntryDate),
                        SubRegOfficeId = request.SubRegOfficeId,
                        IsTransfered = request.IsTransfered,
                        IsSale = request.IsSale,
                        IsBayna = request.IsBayna,
                        TotalLandAmount = request.TotalLandAmount,
                        LandRegAmount = request.LandRegAmount,
                        LandPurchaseAmount = request.LandPurchaseAmount,
                        LandDevelopmentAmount = request.LandDevelopmentAmount,
                        LandOtherAmount = request.LandOtherAmount,
                        Remarks = request.Remarks,
                        FileRemarks = request.FileRemarks,
                        IsDeleted = request.IsDeleted,

                        PlotWiseLandSaleDetails = request.PlotWiseLandSaleDetails != null ? setPlotWiseLandSaleDetail(request.PlotWiseLandSaleDetails) : new List<PlotWiseLandSaleDetail>(),
                        OwnerWiseLandSaleDetails = request.OwnerWiseLandSaleDetails != null ? setOwnerWiseLandSaleDetail(request.OwnerWiseLandSaleDetails) : new List<OwnerWiseLandSaleDetail>(),

                        PlotWiseLandTransferDetails = request.PlotWiseLandTransferDetails != null ? setPlotWiseLandTransferDetail(request.PlotWiseLandTransferDetails) : new List<PlotWiseLandTransferDetail>(),
                        OwnerWiseLandTransferDetails = request.OwnerWiseLandTransferDetails != null ? setOwnerWiseLandTransferDetail(request.OwnerWiseLandTransferDetails) : new List<OwnerWiseLandTransferDetail>(),
                        
                        LandMasterOwnerRelations = request.LandMasterOwnerRelations != null ? setLandMasterOwnerRelation(request.LandMasterOwnerRelations) : new List<LandMasterOwnerRelation>(),
                        LandSalersInfos = request.LandSalersInfos != null ? setlandSalersInfo(request.LandSalersInfos) : new List<LandSalersInfo>(),
                        KhatianDetails = request.KhatianDetails != null ? setKhatianDetail(request.KhatianDetails) : new List<KhatianDetail>(),
                        LandOwnersDetails = request.LandOwnersDetails != null ? setLandOwnersDetail(request.LandOwnersDetails) : new List<LandOwnersDetail>(),
                        BayaDeedDetails = request.BayaDeedDetails != null ? setBayaDeedDetail(request.BayaDeedDetails) : new List<BayaDeedDetail>()
                    };

                    if (request.LandMasterId == Guid.Empty)
                    {
                        landMaster.CreatedBy = request.CreatedBy;
                        landMaster.CreatedAt = DateTime.Now;
                        landMaster.CreatedPcIp = request.CreatedPcIp;
                        landMaster = await _landMasterRepository.AddAsync(landMaster);
                        saveDocument(request.DocumentVms, landMaster.LandMasterId);
                        landMasterResponse.Message = "Deed No " + landMaster.DeedNo + " Saved Successfully!";
                    }                    
                    else
                    {
                        var landMasterById = await _landMasterRepository.GetLandMasterById(request.LandMasterId);
                        if (landMasterById != null && request.IsDeleted == false)
                        {
                            landMaster.CreatedBy = landMasterById.CreatedBy;
                            landMaster.CreatedAt = landMasterById.CreatedAt;
                            landMaster.CreatedPcIp = landMasterById.CreatedPcIp;
                            landMaster.UpdatedBy = request.UpdatedBy;
                            landMaster.UpdatedAt = DateTime.Now;
                            await _landMasterRepository.UpdateLandMaster(landMaster);
                            saveDocument(request.DocumentVms, landMasterById.LandMasterId);
                            landMasterResponse.Message = "Deed No " + landMaster.DeedNo + " Updated Successfully!";
                        }

                        else if (landMasterById != null && request.IsDeleted == true)
                        {
                            landMaster.IsDeleted = true;

                            await _landMasterRepository.UpdateLandMaster(landMaster);
                            saveDocument(request.DocumentVms, landMasterById.LandMasterId);
                            landMasterResponse.Message = "Deed No " + landMaster.DeedNo + " Deleted Successfully!";
                        }

                        else
                        {
                            landMasterResponse.Message = "Data Not Found!";
                        }
                    }
                    landMasterResponse.LandMasterDto = _mapper.Map<CreateOrUpdateLandMasterDto>(landMaster);
                }
                _logger.LogInformation(landMasterResponse.Message);
                return landMasterResponse;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ICollection<PlotWiseLandSaleDetail> setPlotWiseLandSaleDetail(ICollection<PlotWiseLandSaleCommand> plotWiseLandSaleCommand)
        {
            List<PlotWiseLandSaleDetail> plotWiseLandSaleDetails = new();
            foreach (var cmd in plotWiseLandSaleCommand)
            {
                PlotWiseLandSaleDetail plotWiseLandSaleDetail = new()
                {
                    PlotWiseLandSaleDetailId = cmd.PlotWiseLandSaleDetailId,
                    LandMasterId = cmd.LandMasterId,
                    SaleLandMasterId = cmd.SaleLandMasterId,
                    SaleKhatianTypeId = cmd.SaleKhatianTypeId,
                    SaleDagNo = cmd.SaleDagNo,
                    PlotWiseSaleLandAmount = cmd.PlotWiseSaleLandAmount
                };
                plotWiseLandSaleDetails.Add(plotWiseLandSaleDetail);
            }
            return plotWiseLandSaleDetails;
        }

        public ICollection<OwnerWiseLandSaleDetail> setOwnerWiseLandSaleDetail(ICollection<OwnerWiseLandSaleCommand> ownerWiseLandSaleCommand)
        {
            List<OwnerWiseLandSaleDetail> ownerWiseLandSaleDetails = new();
            foreach (var cmd in ownerWiseLandSaleCommand)
            {
                OwnerWiseLandSaleDetail ownerWiseLandSaleDetail = new()
                {
                    OwnerWiseLandSaleDetailId = cmd.OwnerWiseLandSaleDetailId,
                    LandMasterId = cmd.LandMasterId,
                    SaleLandMasterId = cmd.SaleLandMasterId,
                    SaleKhatianTypeId = cmd.SaleKhatianTypeId,
                    SaleOwnerInfoId = cmd.SaleOwnerInfoId,
                    OwnerWiseSaleLandAmount = cmd.OwnerWiseSaleLandAmount
                };
                ownerWiseLandSaleDetails.Add(ownerWiseLandSaleDetail);
            }
            return ownerWiseLandSaleDetails;
        }

        public ICollection<PlotWiseLandTransferDetail> setPlotWiseLandTransferDetail(ICollection<PlotWiseLandTransferDetailCommand> plotWiseLandTransferDetailCommand)
        {
            List<PlotWiseLandTransferDetail> plotWiseLandTransferDetails = new();
            foreach (var cmd in plotWiseLandTransferDetailCommand)
            {
                PlotWiseLandTransferDetail plotWiseLandTransferDetail = new()
                {
                    PlotWiseLandTransferDetailId = cmd.PlotWiseLandTransferDetailId,
                    LandMasterId = cmd.LandMasterId,
                    TransferedLandMasterId = cmd.TransferedLandMasterId,
                    TransferedKhatianTypeId = cmd.TransferedKhatianTypeId,
                    TransferedDagNo = cmd.TransferedDagNo,
                    PlotWiseTransferedLandAmount = cmd.PlotWiseTransferedLandAmount
                };
                plotWiseLandTransferDetails.Add(plotWiseLandTransferDetail);
            }
            return plotWiseLandTransferDetails;
        }
        public ICollection<OwnerWiseLandTransferDetail> setOwnerWiseLandTransferDetail(ICollection<OwnerWiseLandTransferDetailCommand> ownerWiseLandTransferDetailCommand)
        {
            List<OwnerWiseLandTransferDetail> ownerWiseLandTransferDetails = new();
            foreach (var cmd in ownerWiseLandTransferDetailCommand)
            {
                OwnerWiseLandTransferDetail ownerWiseLandTransferDetail = new()
                {
                    OwnerWiseLandTransferDetailId = cmd.OwnerWiseLandTransferDetailId,
                    LandMasterId = cmd.LandMasterId,
                    TransferedLandMasterId = cmd.TransferedLandMasterId,
                    TransferedKhatianTypeId = cmd.TransferedKhatianTypeId,
                    TransferedOwnerInfoId = cmd.TransferedOwnerInfoId,
                    OwnerWiseTransferedLandAmount = cmd.OwnerWiseTransferedLandAmount
                };
                ownerWiseLandTransferDetails.Add(ownerWiseLandTransferDetail);
            }
            return ownerWiseLandTransferDetails;
        }
        public List<LandMasterOwnerRelation> setLandMasterOwnerRelation(ICollection<LandMasterOwnerRelationCommand> landOwnerTypes)
        {
            List<LandMasterOwnerRelation> landMasterOwnerRelations = new();
            foreach (var type in landOwnerTypes)
            {
                LandMasterOwnerRelation model = new();
                {
                    model.LandMasterOwnerRelationId = type.LandMasterOwnerRelationId;
                    model.LandOwnerTypeId = type.LandOwnerTypeId;
                    model.LandMasterId = type.LandMasterId;
                    model.OtherRemarks = type.OtherRemarks;
                }
                landMasterOwnerRelations.Add(model);
            }
            return landMasterOwnerRelations;
        }
        public ICollection<LandSalersInfo> setlandSalersInfo(ICollection<LandSalersInfoCommand> landSalersInfos)
        {
            List<LandSalersInfo> landSellrs = new();
            foreach (var cmd in landSalersInfos)
            {
                LandSalersInfo landseller = new()
                {
                    SalersInfoId = cmd.SalersInfoId,
                    LandMasterId = cmd.LandMasterId,
                    SalerName = cmd.SalerName,
                    SalerFatherName = cmd.SalerFatherName,
                    SalerAddress = cmd.SalerAddress
                };
                landSellrs.Add(landseller);
            }
            return landSellrs;
        }

        public ICollection<KhatianDetail> setKhatianDetail(ICollection<KhatianDetailCommand> khatianDetailCommand)
        {
            List<KhatianDetail> khatianDetails = new();
            foreach (var cmd in khatianDetailCommand)
            {
                KhatianDetail khatianDetail = new()
                {
                    KhatianDetailId = cmd.KhatianDetailId,
                    LandMasterId = cmd.LandMasterId,
                    MouzaId = cmd.MouzaId,
                    KhatianTypeId = cmd.KhatianTypeId,
                    KhatianNo = cmd.KhatianNo,
                    DagNo = cmd.DagNo,
                    RecordedOwnerName = cmd.RecordedOwnerName
                };
                khatianDetails.Add(khatianDetail);
            }
            return khatianDetails;
        }
        
        public ICollection<LandOwnersDetail> setLandOwnersDetail(ICollection<LandOwnersDetailCommand> landOwnersDetailCommands)
        {
            List<LandOwnersDetail> landOwnersDetails = new();
            foreach (var cmd in landOwnersDetailCommands)
            {
                LandOwnersDetail landOwnersDetail = new()
                {
                    LandOwnersDetailId = cmd.LandOwnersDetailId,
                    LandMasterId = cmd.LandMasterId,
                    OwnerInfoId = cmd.OwnerInfoId,
                    SaleOwnerName = cmd.SaleOwnerName,
                    MouzaId = cmd.MouzaId,
                    LandAmount = cmd.LandAmount,
                    OwnerRegAmount = cmd.OwnerRegAmount,
                    OwnerPurchaseAmount = cmd.OwnerPurchaseAmount
                };
                landOwnersDetails.Add(landOwnersDetail);
            }
            return landOwnersDetails;
        }

        private void saveDocument(ICollection<DocumentVM> requestDocumentVms, Guid lmid)
        {
            foreach (var item in requestDocumentVms)
            {
                item.ModuleMasterId = lmid;
                _documentRepository.AddRemoveDocument(item);
            }
        }

        public ICollection<BayaDeedDetail> setBayaDeedDetail(ICollection<BayaDeedDetailCommand> bayaDeedDetailCommand)
        {
            List<BayaDeedDetail> bayaDeedDetails = new();
            foreach (var cmd in bayaDeedDetailCommand)
            {
                BayaDeedDetail bayaDeedDetail = new()
                {
                    BayaDeedDetailId = cmd.BayaDeedDetailId,
                    LandMasterId = cmd.LandMasterId,
                    BayaDeedNo = cmd.BayaDeedNo,
                    BayaDeedDate = cmd.BayaDeedDate
                };
                bayaDeedDetails.Add(bayaDeedDetail);
            }
            return bayaDeedDetails;
        }
    }
}

