using Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId;
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
    public class FileNoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FileNoController> _logger;

        public FileNoController(IMediator mediator, ILogger<FileNoController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("fileNoList/{fileCodeId}", Name = "GetFileNoListByFileCodeId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<FileNoListByFileCodeIdVm>>> GetFileNoListByFileCodeId(Guid fileCodeId)
        {
            var fileNolist = new GetFileNoListByFileCodeIdQuery() { FileCodeInfoId = fileCodeId };
            var result = await _mediator.Send(fileNolist);
            return Ok(result);
        }
    }
}
