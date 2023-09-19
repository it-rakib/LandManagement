using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.CmnSubRegOfficeInfo.Commands.CreateUpdateCmnSubRegOffice;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId;
using Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeGrid;
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
    public class CmnSubRegOfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnSubRegOfficeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<CmnSubRegOfficeGridVM>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllCmnSubRegOfficeGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateCmnSubRegOffice")]
        public async Task<ActionResult<string>> CreateUpdateCmnSubRegOffice([FromBody] CreateCmnSubRegOfficeCommand createCmnSubRegOfficeCommand)
        {
            var response = await _mediator.Send(createCmnSubRegOfficeCommand);
            return Ok(response);
        }

        [HttpGet("subRegOfc/{upozilaId}", Name = "GetSubRegOfficeByUpozilaId")]
        public async Task<ActionResult<CmnSubRegOfficeByUpozilaIdVM>> GetSubRegOfficeByUpozilaId(Guid upozilaId)
        {
            var GgetSubRegOfficeByUpozilaId = new GetAllCmnSubRegOfficeByUpozilaIdQuery() { UpozilaId = upozilaId };
            var list = await _mediator.Send(GgetSubRegOfficeByUpozilaId);
            return Ok(list);
        }
    }
}
