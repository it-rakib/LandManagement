using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.CmnDistrictInfo.Commands.CreateUpdateCmnDistrict;
using Land.Application.Features.CmnDistrictInfo.Commands.DeleteCmnDistrict;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictGrid;
using Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictList;
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
    public class CmnDistrictController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnDistrictController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllCmnDistrict")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CmnDistrict>>> GetAllCmnDistrict()
        {
            var allDistrict = await _mediator.Send(new GetAllCmnDistrictListQuery());
            return Ok(allDistrict);
        }

        [HttpGet("district/{divisionId}", Name = "GetAllCmnDistrictByDivisionId")]
        public async Task<ActionResult<CmnDistrictByDivisionIdVM>> GetAllCmnDistrictByDivisionId(Guid divisionId)
        {
            var GetAllDistrictByDivisionId = new GetAllCmnDistrictByDivisionIdQuery() { DivisionId = divisionId };
            var list = await _mediator.Send(GetAllDistrictByDivisionId);
            return Ok(list);
        }

        [HttpDelete("{id}", Name = "DeleteCmnDistrict")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCmnDistrict(Guid id)
        {
            var districtToDelete = new DeleteCmnDistrictCommand() { DistrictId = id };
            var response = await _mediator.Send(districtToDelete);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<CmnDistrictGridVM>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllCmnDistrictGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateCmnDistrict")]
        public async Task<ActionResult<string>> CreateUpdateCmnDistrict([FromBody] CreateCmnDistrictCommand createCmnDistrictCommand)
        {
            var response = await _mediator.Send(createCmnDistrictCommand);
            return Ok(response);
        }
    }
}
