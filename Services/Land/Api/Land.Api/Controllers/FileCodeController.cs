using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.FileCode.Commands.CreateUpdateFileCode;
using Land.Application.Features.FileCode.Queries.GetAllFileCodeGrid;
using Land.Application.Features.FileCode.Queries.GetAllFileCodeList;
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
    public class FileCodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FileCodeController> _logger;

        public FileCodeController(IMediator mediator, ILogger<FileCodeController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("all", Name = "GetAllFileCodeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<FileCodeListVm>>> GetAllFileCodeList()
        {
            var fileCodeList = await _mediator.Send(new GetAllFileCodeListQuery());
            return Ok(fileCodeList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<GetAllFileCodeGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllFileCodeGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateFileCodeInfo")]
        public async Task<ActionResult<string>> CreateUpdateFileCodeInfo([FromBody] CreateUpdateFileCodeCommand createUpdateFileCodeCommand)
        {
            var response = await _mediator.Send(createUpdateFileCodeCommand);
            return Ok(response);
        }
    }
}
