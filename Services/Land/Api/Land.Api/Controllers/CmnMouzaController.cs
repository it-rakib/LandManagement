using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.CmnMouzaInfo.Commands.CreateUpdateCmnMouza;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId;
using Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaGrid;
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
    public class CmnMouzaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnMouzaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<CmnMouzaGridVM>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllCmnMouzaGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateCmnMouza")]
        public async Task<ActionResult<string>> CreateUpdateCmnMouza([FromBody] CreateCmnMouzaCommand createCmnMouzaCommand)
        {
            var response = await _mediator.Send(createCmnMouzaCommand);
            return Ok(response);
        }

        [HttpGet("mouza/{upozilaId}", Name = "GetMouzaByUpozilaId")]
        public async Task<ActionResult<CmnMouzaByUpozilaIdVM>> GetMouzaByUpozilaId(Guid upozilaId)
        {
            var GetMouzaByUpozilaId = new GetAllCmnMouzaByUpozilaIdQuery() { UpozilaId = upozilaId };
            var list = await _mediator.Send(GetMouzaByUpozilaId);
            return Ok(list);
        }
    }
}
