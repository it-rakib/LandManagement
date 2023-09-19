using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.CmnDivisionInfo.Commands.CreateUpdateCmnDivision;
using Land.Application.Features.CmnDivisionInfo.Commands.DeleteCmnDivision;
using Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionGrid;
using Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionList;
using Land.Application.Features.CmnDivisionInfo.Queries.GetCmnDivisionById;
using Land.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnDivisionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnDivisionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllCmnDivision")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CmnDivision>>> GetAllCmnDivision()
        {
            var allDivision = await _mediator.Send(new GetAllCmnDivisionListQuery());
            return Ok(allDivision);
        }

        [HttpGet("{id}", Name = "GetCmnDivisionById")]
        public async Task<ActionResult<CmnDivisionByIdVM>> GetCmnDivisionById(Guid id)
        {
            var getCmnDivisionById = new GetCmnDivisionByIdQuery() { DivisionId = id };
            var list = await _mediator.Send(getCmnDivisionById);
            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<GetAllCmnDivisionGridVM>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllCmnDivisionGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateCmnDivision")]
        public async Task<ActionResult<string>> CreateUpdateCmnDivision([FromBody] CreateCmnDivisionCommand createCmnDivisionCommand)
        {
            var response = await _mediator.Send(createCmnDivisionCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteCmnDivision")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCmnDivision(Guid id)
        {
            var divisionToDelete = new DeleteCmnDivisionCommand() { DivisionId = id };
            var response = await _mediator.Send(divisionToDelete);
            return Ok(response);
        }
    }
}
