using Land.Application.Features.CmnDocument.Commands.CreateUpdateDocumentCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnDocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CmnDocumentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //[HttpGet("all", Name = "GetAllBuyerBrand")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult<List<BuyerBrandListVm>>> GetAll()
        //{
        //    var allBuyerBrand = await _mediator.Send(new GetBuyerBrandListQuery());
        //    return Ok(allBuyerBrand);
        //}

        [HttpPost]
        [Route("CreateUpdateCmnDocument")]
        public async Task<ActionResult<string>> CreateUpdateCmnDocument([FromBody] CreateOrUpdateCmnDocumentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
