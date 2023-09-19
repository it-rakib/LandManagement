using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryCompanyGrid;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerMouzaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerUpozilaListByOwnerInfoId;
using Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryPersonGrid;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandOwnersDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LandOwnersDetailController> _logger;

        public LandOwnersDetailController(IMediator mediator, ILogger<LandOwnersDetailController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryPersonGridAsync")]
        public async Task<ActionResult<List<GetAllLandSummaryPersonGridVm>>> GetAllLandSummaryPersonGridAsync([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryPersonGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryCompanyGridAsync")]
        public async Task<ActionResult<List<GetAllLandSummaryCompanyGridVm>>> GetAllLandSummaryCompanyGridAsync([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryCompanyGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandOwnerGridAsync")]
        public async Task<ActionResult<List<LandOwnerGridVm>>> GetAllLandOwnerGridAsync([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandOwnerGridQuery() { options = options });
            return Ok(allData);
        }

        //Land Owner Detail By LandMaster Id & MouzaId
        [HttpGet("landOwnerDetail/{landMasterId},{mouzaId}", Name = "GetAllLandOwnerDetailByLandMasterIdMouzaId")]
        public async Task<ActionResult<List<LandOwnerDetailByLandMasterIdMouzaIdVm>>> GetAllLandOwnerDetailByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId)
        {
            var landOwnerDetail = new GetAllLandOwnerDetailByLandMasterIdMouzaIdQuery() { LandMasterId = landMasterId, MouzaId = mouzaId };
            var list = await _mediator.Send(landOwnerDetail);
            return Ok(list);
        }

        //Land Owner  District List By Owner Info Id
        [HttpGet("landOwnerDistrictList/{ownerInfoId}", Name = "GetAllLandSummaryOwnerDistrictListByOwnerInfoId")]
        public async Task<ActionResult<List<LandSummaryOwnerDistrictListByOwnerInfoIdVm>>> GetAllLandSummaryOwnerDistrictListByOwnerInfoId(Guid ownerInfoId)
        {
            var landOwnerDistrictList = new GetAllLandSummaryOwnerDistrictListByOwnerInfoIdQuery() { OwnerInfoId = ownerInfoId };
            var list = await _mediator.Send(landOwnerDistrictList);
            return Ok(list);
        }

        //Land Owner  Upozaila List By Owner Info Id
        [HttpGet("landOwnerUpozilaList/{ownerInfoId}", Name = "GetAllLandSummaryOwnerUpozilaListByOwnerInfoId")]
        public async Task<ActionResult<List<LandSummaryOwnerUpozilaListByOwnerInfoIdVm>>> GetAllLandSummaryOwnerUpozilaListByOwnerInfoId(Guid ownerInfoId)
        {
            var landOwnerUpozilaList = new GetAllLandSummaryOwnerUpozilaListByOwnerInfoIdQuery() { OwnerInfoId = ownerInfoId };
            var list = await _mediator.Send(landOwnerUpozilaList);
            return Ok(list);
        }

        //Land Owner  Mouza List By Owner Info Id
        [HttpGet("landOwnerMouzaList/{ownerInfoId}", Name = "GetAllLandSummaryOwnerMouzaListByOwnerInfoId")]
        public async Task<ActionResult<List<LandSummaryOwnerMouzaListByOwnerInfoIdVm>>> GetAllLandSummaryOwnerMouzaListByOwnerInfoId(Guid ownerInfoId)
        {
            var landOwnerMouzaList = new GetAllLandSummaryOwnerMouzaListByOwnerInfoIdQuery() { OwnerInfoId = ownerInfoId };
            var list = await _mediator.Send(landOwnerMouzaList);
            return Ok(list);
        }

        //Land Summary By Land Master Id
        [HttpGet("landSummary/{landMasterId}", Name = "GetAllLandSummaryByLandMasterId")]
        public async Task<ActionResult<List<LandSummaryByLandMasterIdVm>>> GetAllLandSummaryByLandMasterId(Guid landMasterId)
        {
            var landSummary = new GetAllLandSummaryByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(landSummary);
            return Ok(list);
        }
    }
}
