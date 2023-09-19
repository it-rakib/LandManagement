using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId;
using Land.Application.Features.FileLocation.Queries.GetAllFileLocationGrid;
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
    public class FileLocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FileLocationController> _logger;

        public FileLocationController(IMediator mediator, ILogger<FileLocationController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("CreateOrUpdateFileLocation")]
        public async Task<ActionResult<string>> Create([FromBody] CreateFileLocationCommand createFileLocationCommand)
        {
            try
            {
                var response = await _mediator.Send(createFileLocationCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to insert Land Information: {ex}");
                return BadRequest("Failed to insert Land Information");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<FileLocationGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllFileLocationGridQuery() { options = options });
            return Ok(allData);
        }

        //File Location Detail List By FileLocationMasterId
        [HttpGet("fileLocationDetails/{fileLocationMasterId}", Name = "GetAllFileLocationDetailListByFileLocationMasterId")]
        public async Task<ActionResult<List<FileLocationDetailListByFileLocationMasterIdVm>>> GetAllFileLocationDetailListByFileLocationMasterId(Guid fileLocationMasterId)
        {
            var details = new GetAllFileLocationDetailListByFileLocationMasterIdQuery() { FileLocationMasterId = fileLocationMasterId };
            var list = await _mediator.Send(details);
            return Ok(list);
        }

        //File Location Detail List
        [HttpGet("fileLocationDetailList", Name = "GetAllFileLocationDetailList")]
        public async Task<ActionResult<List<FileLocationDetailListVm>>> GetAllFileLocationDetailList()
        {
            var details = new GetAllFileLocationDetailListQuery();
            var list = await _mediator.Send(details);
            return Ok(list);
        }
    }
}
