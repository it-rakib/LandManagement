using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandOwnerInfo.Commands.CreateUpdateLandOwner;
using Land.Application.Features.LandOwnerInfo.Commands.DeleteLandOwner;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoGrid;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoList;
using Land.Application.Features.LandOwnerInfo.Queries.GetTotalCompany;
using Land.Application.Features.LandOwnerInfo.Queries.GetTotalPerson;
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
    public class OwnerInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnerInfoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllOwnerInfoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllOwnerInfoListVm>>> GetAllOwnerInfoList()
        {
            var allOwnerInfo = await _mediator.Send(new GetAllOwnerInfoListQuery());
            return Ok(allOwnerInfo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<OwnerInfoGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllOwnerInfoGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [Route("CreateUpdateLandOwner")]
        public async Task<ActionResult<string>> CreateUpdateLandOwner([FromBody] CreateLandOwnerCommand createLandOwnerCommand)
        {
            var response = await _mediator.Send(createLandOwnerCommand);
            return Ok(response);
        }

        [HttpGet("GetTotalCompany", Name = "GetTotalCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> GetTotalCompany()
        {
            var totalCompany = await _mediator.Send(new GetTotalCompanyQuery());
            return Ok(totalCompany);
        }

        [HttpGet("GetTotalPerson", Name = "GetTotalPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> GetTotalPerson()
        {
            var totalPerson = await _mediator.Send(new GetTotalPersonQuery());
            return Ok(totalPerson);
        }

        [HttpDelete("{id}", Name = "DeleteOwnerInfo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var ownerInfoToDelete = new DeleteLandOwnerCommand() { OwnerInfoId = id };
            await _mediator.Send(ownerInfoToDelete);
            return NoContent();
        }
    }
}
