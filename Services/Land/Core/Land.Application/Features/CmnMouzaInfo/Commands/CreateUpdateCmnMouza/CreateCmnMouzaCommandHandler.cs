using AutoMapper;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnMouzaInfo.Commands.CreateUpdateCmnMouza
{
    public class CreateCmnMouzaCommandHandler : IRequestHandler<CreateCmnMouzaCommand, CreateCmnMouzaCommandResponse>
    {
        private readonly ICmnMouzaRepository _cmnMouzaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCmnMouzaCommandHandler> _logger;

        public CreateCmnMouzaCommandHandler(ICmnMouzaRepository cmnMouzaRepository, IMapper mapper, ILogger<CreateCmnMouzaCommandHandler> logger)
        {
            _cmnMouzaRepository = cmnMouzaRepository ?? throw new ArgumentNullException(nameof(cmnMouzaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateCmnMouzaCommandResponse> Handle(CreateCmnMouzaCommand request, CancellationToken cancellationToken)
        {
            var mouzaCommandResponse = new CreateCmnMouzaCommandResponse();

            try
            {
                var validator = new CreateCmnMouzaCommandValidator(_cmnMouzaRepository);
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    mouzaCommandResponse.Success = false;
                    mouzaCommandResponse.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        mouzaCommandResponse.Message = mouzaCommandResponse.Message + "  " + error.ErrorMessage;
                        mouzaCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                        _logger.LogError(mouzaCommandResponse.Message);
                    }
                }
                if (mouzaCommandResponse.Success)
                {
                    var mouza = new CmnMouza()
                    {
                        MouzaId = request.MouzaId,
                        MouzaName = request.MouzaName,
                        UpozilaId = request.UpozilaId
                    };
                    if (mouza.MouzaId == Guid.Empty)
                    {
                        mouza = await _cmnMouzaRepository.AddAsync(mouza);
                        mouzaCommandResponse.Message = mouza.MouzaName + " Saved Successfully";
                        _logger.LogInformation($"{mouzaCommandResponse.Message = mouza.MouzaName + " is Successfully Created"}");
                    }
                    else
                    {
                        mouza = await _cmnMouzaRepository.Update(mouza);
                        mouzaCommandResponse.Message = mouza.MouzaName + " Updated Successfully";
                    }
                    mouzaCommandResponse.MouzaDTO = _mapper.Map<CreateCmnMouzaDTO>(mouza);

                }
            }
            catch (Exception ex)
            {

                mouzaCommandResponse.Success = false;
                mouzaCommandResponse.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return mouzaCommandResponse;
        }
    }
}
