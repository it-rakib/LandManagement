using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.CmnUpozilaInfo.Commands.CreateUpdateCmnUpozila;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId;
using Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaGrid;
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
    public class CmnUpozilaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnUpozilaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<CmnUpozilaGridVM>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllCmnUpozilaGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateCmnUpozila")]
        public async Task<ActionResult<string>> CreateUpdateCmnUpozila([FromBody] CreateCmnUpozilaCommand createCmnUpozilaCommand)
        {
            var response = await _mediator.Send(createCmnUpozilaCommand);
            return Ok(response);
        }

        [HttpGet("upozila/{districtId}", Name = "GetAllCmnUpozilaByDistrictId")]
        public async Task<ActionResult<CmnUpozilaByDistrictIdVM>> GetAllCmnUpozilaByDistrictId(Guid districtId)
        {
            var GetAllCmnUpozilaByDistrictId = new GetAllCmnUpozilaByDistrictIdQuery() { DistrictId = districtId };
            var list = await _mediator.Send(GetAllCmnUpozilaByDistrictId);
            return Ok(list);
        }
    }
}
