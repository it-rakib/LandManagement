using Land.Application.Features.RackNo.Queries.GetAllRackNoListByAlmirahId;
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
    public class RackNoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RackNoController> _logger;

        public RackNoController(IMediator mediator, ILogger<RackNoController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("rackNoList/{almirahId}", Name = "GetAllRackNoListByAlmirahId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<RackNoListByAlmirahIdVm>>> GetAllRackNoListByAlmirahId(Guid almirahId)
        {
            var rackNolist = new GetAllRackNoListByAlmirahIdQuery() { AlmirahNoInfoId = almirahId };
            var result = await _mediator.Send(rackNolist);
            return Ok(result);
        }
    }
}
