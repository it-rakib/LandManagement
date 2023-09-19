using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnUpozilaInfo.Commands.CreateUpdateCmnUpozila
{
    public class CreateCmnUpozilaCommandHandler : IRequestHandler<CreateCmnUpozilaCommand, CreateCmnUpozilaCommandResponse>
    {

        private readonly ICmnUpozilaRepository _cmnUpozilaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCmnUpozilaCommandHandler> _logger;

        public CreateCmnUpozilaCommandHandler(ICmnUpozilaRepository cmnUpozilaRepository, IMapper mapper, ILogger<CreateCmnUpozilaCommandHandler> logger)
        {
            _cmnUpozilaRepository = cmnUpozilaRepository ?? throw new ArgumentNullException(nameof(cmnUpozilaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateCmnUpozilaCommandResponse> Handle(CreateCmnUpozilaCommand request, CancellationToken cancellationToken)
        {
            var upozilaCommandResponse = new CreateCmnUpozilaCommandResponse();

            try
            {
                var validator = new CreateCmnUpozilaCommandValidator(_cmnUpozilaRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    upozilaCommandResponse.Success = false;
                    upozilaCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        upozilaCommandResponse.Message = upozilaCommandResponse.Message + "  " + error.ErrorMessage;
                        upozilaCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(upozilaCommandResponse.Message);
                    }
                }
                if (upozilaCommandResponse.Success)
                {
                    var upozila = new CmnUpozila()
                    {
                        UpozilaId = request.UpozilaId,
                        UpozilaName = request.UpozilaName,
                        DistrictId = request.DistrictId
                    };
                    if (upozila.UpozilaId == Guid.Empty)
                    {
                        upozila = await _cmnUpozilaRepository.AddAsync(upozila);
                        upozilaCommandResponse.Message = upozila.UpozilaName + " Saved Successfully";
                        _logger.LogInformation($"{upozilaCommandResponse.Message = upozila.UpozilaName + " is Successfully Created"}");
                    }
                    else
                    {
                        upozila = await _cmnUpozilaRepository.Update(upozila);
                        upozilaCommandResponse.Message = upozila.UpozilaName + " Updated Successfully";
                    }
                    upozilaCommandResponse.UpozilaDTO = _mapper.Map<CreateCmnUpozilaDTO>(upozila);

                }
            }
            catch (Exception ex)
            {

                upozilaCommandResponse.Success = false;
                upozilaCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return upozilaCommandResponse;
        }
    }
}
