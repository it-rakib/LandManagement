using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Land.Application.Features.CmnBanglaYearInfo.Queries.GetAllCmnBanglaYearList;
using Land.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnBanglaYearController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnBanglaYearController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllCmnBanglaYear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CmnBanglaYear>>> GetAllCmnBanglaYear()
        {
            var allCmnBanglaYear = await _mediator.Send(new GetAllCmnBanglaYearListQuery());
            return Ok(allCmnBanglaYear);
        }
    }
}
