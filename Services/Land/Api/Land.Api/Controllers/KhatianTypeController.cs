using Land.Application.Features.KhatiyanTypeInfo.Queries.GetAllKhatiyanTypes;
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
    public class KhatianTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KhatianTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllKhatianTypeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllKhatiyanTypesVm>>> GetAllKhatianTypeList()
        {
            var allKhatiyantype = await _mediator.Send(new GetAllKhatiyanTypesQuery());
            return Ok(allKhatiyantype);
        }
    }
}
