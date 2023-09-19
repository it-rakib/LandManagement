using Land.Application.Features.KhatiyanTypeInfo.Queries.GetAllKhatiyanTypes;
using Land.Application.Features.MapTypeInfo.Queries.MapTypeListCombo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MapTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllMapTypeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MapTypeListComboVm>>> GetAllMapTypeList()
        {
            var allMaptype = await _mediator.Send(new MapTypeListComboQuery());
            return Ok(allMaptype);
        }
    }
}
