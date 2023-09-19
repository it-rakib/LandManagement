using Land.Application.Features.AlmirahNo.Queries.GetAllAlmirahNoList;
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
    public class AlmirahNoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AlmirahNoController> _logger;

        public AlmirahNoController(IMediator mediator, ILogger<AlmirahNoController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("all", Name = "GetAllAlmirahNoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AlmirahNoListVm>>> GetAllAlmirahNoList()
        {
            var almirahNoList = await _mediator.Send(new GetAllAlmirahNoListQuery());
            return Ok(almirahNoList);
        }
    }
}
