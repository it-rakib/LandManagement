using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax;
using Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandDevelopmentTaxController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LandDevelopmentTaxController> _logger;

        public LandDevelopmentTaxController(IMediator mediator, ILogger<LandDevelopmentTaxController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<LandDevelopmentTaxGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandDevelopmentTaxGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateOrUpdateLandDevelopmentTax")]
        public async Task<ActionResult<string>> Create([FromBody] CreateOrUpdateLandDevelopmentTaxCommand createOrUpdateLandDevelopmentTaxCommand)
        {
            try
            {
                var response = await _mediator.Send(createOrUpdateLandDevelopmentTaxCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to insert Land Information: {ex}");
                return BadRequest("Failed to insert Land Information");
            }
        }
    }
}
