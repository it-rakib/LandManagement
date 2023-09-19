using Land.Application.Features.SheetNo.Queries;
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
    public class SheetNoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SheetNoController> _logger;

        public SheetNoController(IMediator mediator, ILogger<SheetNoController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("all", Name = "GetAllSheetNoInfoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllSheetNoInfoListVm>>> GetAllSheetNoInfoList()
        {
            var allSheet = await _mediator.Send(new GetAllSheetNoInfoListQuery());
            return Ok(allSheet);
        }
    }
}
