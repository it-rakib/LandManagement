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

namespace Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap
{
    public class CreateUpdateLandMapCommandHandler : IRequestHandler<CreateUpdateLandMapCommand, CreateUpdateLandMapCommandResponse>
    {
        private readonly ILandMapRepository _landMapRepository;
        private readonly ICmnDocumentRepository _documentRepository;
        private readonly ILogger<CreateUpdateLandMapCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateUpdateLandMapCommandHandler(ILandMapRepository landMapRepository, ICmnDocumentRepository documentRepository, ILogger<CreateUpdateLandMapCommandHandler> logger, IMapper mapper)
        {
            _landMapRepository = landMapRepository ?? throw new ArgumentNullException(nameof(landMapRepository));
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateUpdateLandMapCommandResponse> Handle(CreateUpdateLandMapCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateUpdateLandMapCommandResponse();
            try
            {
                var validator = new CreateUpdateLandMapCommandValidator(_landMapRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        response.Message = response.Message + Environment.NewLine + error.ErrorMessage;
                        response.ValidationErrors.Add(error.ErrorMessage);
                    }
                    _logger.LogError(response.Message);
                }
                if (response.Success)
                {
                    var landMap = new LandMap()
                    {
                        LandMapId = request.LandMapId,
                        DivisionId = request.DivisionId,
                        DistrictId = request.DistrictId,
                        UpozilaId = request.UpozilaId,
                        MouzaId = request.MouzaId,
                        MapTypeId = request.MapTypeId,
                        //MapType = request.MapType,
                        SheetNoInfoId = request.SheetNoInfoId,
                        Remarks = request.Remarks,
                        FileRemarks = request.FileRemarks,
                        IsDeleted = false
                        //LandMapKhatianRelations = request.LandMapKhatianRelations != null ? setLandMapKhatianRelation(request.LandMapKhatianRelations) : new List<LandMapKhatianRelation>(),
                    };
                    if(request.LandMapId == Guid.Empty)
                    {
                        landMap.CreatedPcIp = request.CreatedPcIp;
                        landMap.CreatedBy = request.CreatedBy;
                        landMap.CreatedAt = DateTime.Now;
                        landMap.UpdatedAt = request.UpdatedAt;
                        landMap.UpdatedBy = request.UpdatedBy;
                        landMap.DeletedBy = request.DeletedBy;
                        landMap = await _landMapRepository.AddAsync(landMap);
                        saveDocument(request.DocumentVms, landMap.LandMapId);
                        response.Message = "Saved Successfully!";
                    }
                    else
                    {
                        var landMapId = await _landMapRepository.GetLandMapById(request.LandMapId);
                        //landMapId.LandMapKhatianRelations = request.LandMapKhatianRelations != null ? setLandMapKhatianRelation(request.LandMapKhatianRelations) : new List<LandMapKhatianRelation>();
                        if (landMapId != null && (request.IsDeleted == false || request.IsDeleted == null ))
                        {
                            landMap.CreatedBy = landMapId.CreatedBy;
                            landMap.CreatedAt = landMapId.CreatedAt;
                            landMap.CreatedPcIp = landMapId.CreatedPcIp;
                            landMap.UpdatedBy = request.UpdatedBy;
                            landMap.UpdatedAt = DateTime.Now;
                            landMap.IsDeleted = false;
                            await _landMapRepository.Update(landMap);
                            saveDocument(request.DocumentVms, request.LandMapId);
                            response.Message = "Updated Successfully!";
                        }
                        else if (landMapId != null && request.IsDeleted == true)
                        {
                            landMap.IsDeleted = true;
                            await _landMapRepository.Update(landMap);
                            saveDocument(request.DocumentVms, request.LandMapId);
                            response.Message = "Deleted Successfully!";
                        }
                        else
                        {
                            response.Message = "Data Not Found!";
                        }
                    }
                    response.LandMapDto = _mapper.Map<CreateUpdateLandMapDto>(landMap);
                }
                _logger.LogInformation(response.Message);
                return response;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        //public static List<LandMapKhatianRelation> setLandMapKhatianRelation(ICollection<LandMapKhatianRelationCommand> landMapKhatianRelations)
        //{
        //    List<LandMapKhatianRelation> mapKhatianRelations = new();
        //    foreach (var type in landMapKhatianRelations)
        //    {
        //        LandMapKhatianRelation model = new();
        //        {
        //            model.LandMapKhatianRelationId = type.LandMapKhatianRelationId;
        //            model.LandMapId = type.LandMapId;
        //            model.KhatianTypeId = type.KhatianTypeId;
        //            model.OtherRemarks = type.OtherRemarks;
        //        }
        //        mapKhatianRelations.Add(model);
        //    }
        //    return mapKhatianRelations;
        //}

        private void saveDocument(ICollection<DocumentVM> requestDocumentVms, Guid mapid)
        {
            foreach (var item in requestDocumentVms)
            {
                item.ModuleMasterId = mapid;
                _documentRepository.AddRemoveDocument(item);
            }
        }
    }
}
