using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax;
using Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid;
using Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap;
using Land.Application.Features.LandMapInfo.Queries.GetAllMapInfoGrid;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandMapInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LandMapInfoController> _logger;

        public LandMapInfoController(IMediator mediator, ILogger<LandMapInfoController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<GridEntity<GetAllMapInfoGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllMapInfoGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateOrUpdateLandMap")]
        public async Task<ActionResult<string>> Create([FromBody] CreateUpdateLandMapCommand createUpdateLandMapCommand)
        {
            try
            {
                var response = await _mediator.Send(createUpdateLandMapCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to insert Land Map {ex}");
                return BadRequest("Failed to insert Land Map");
            }
        }
    }
}
