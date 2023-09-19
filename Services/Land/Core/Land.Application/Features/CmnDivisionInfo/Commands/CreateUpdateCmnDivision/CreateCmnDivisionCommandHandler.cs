using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDivisionInfo.Commands.CreateUpdateCmnDivision
{
    public class CreateCmnDivisionCommandHandler : IRequestHandler<CreateCmnDivisionCommand, CreateCmnDivisionCommandResponse>
    {
        private readonly ICmnDivisionRepository _cmnDivisionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCmnDivisionCommandHandler> _logger;

        public CreateCmnDivisionCommandHandler(ICmnDivisionRepository cmnDivisionRepository, IMapper mapper, ILogger<CreateCmnDivisionCommandHandler> logger)
        {
            _cmnDivisionRepository = cmnDivisionRepository ?? throw new ArgumentNullException(nameof(cmnDivisionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateCmnDivisionCommandResponse> Handle(CreateCmnDivisionCommand request, CancellationToken cancellationToken)
        {
            var divisionCommandResponse = new CreateCmnDivisionCommandResponse();
            try
            {
                var validator = new CreateCmnDivisionCommandValidator(_cmnDivisionRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    divisionCommandResponse.Success = false;
                    divisionCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        divisionCommandResponse.Message = divisionCommandResponse.Message + "  " + error.ErrorMessage;
                        divisionCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(divisionCommandResponse.Message);
                    }
                }
                if (divisionCommandResponse.Success)
                {
                    var division = new CmnDivision()
                    {
                        DivisionId = request.DivisionId,
                        DivisionName = request.DivisionName
                    };
                    if (division.DivisionId == Guid.Empty)
                    {
                        division = await _cmnDivisionRepository.AddAsync(division);
                        divisionCommandResponse.Message = division.DivisionName + " Saved Successfully";
                        _logger.LogInformation($"{divisionCommandResponse.Message = division.DivisionName + " is Successfully Created"}");
                    }
                    else
                    {
                        division = await _cmnDivisionRepository.Update(division);
                        divisionCommandResponse.Message = division.DivisionName + " Updated Successfully";
                    }
                    divisionCommandResponse.DivisionDTO = _mapper.Map<CreateCmnDivisionDTO>(division);
                }
            }
            catch (Exception ex)
            {

                divisionCommandResponse.Success = false;
                divisionCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return divisionCommandResponse;
        }
    }
}
