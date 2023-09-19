using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList;
using Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId;
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
    public class LandOwnerTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LandOwnerTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("all", Name = "GetAllLandOwnerTypeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllLandOwnerTypeListVm>>> GetAllLandOwnerTypeList()
        {
            var allLandOwnerType = await _mediator.Send(new GetAllLandOwnerTypeListQuery());
            return Ok(allLandOwnerType);
        }

        [HttpGet("ownerType/{landMasterId}", Name = "GetAllLandOwnerTypeListByLandMasterId")]
        public async Task<ActionResult<LandOwnerTypeListByLandMasterIdVm>> GetAllLandOwnerTypeListByLandMasterId(Guid landMasterId)
        {
            var landOwnerType = new GetAllLandOwnerTypeListByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(landOwnerType);
            return Ok(list);
        }
    }
}
