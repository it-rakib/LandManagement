using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDivisionId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByUpozilaId;
using Land.Application.Features.MutationMasterInfo.Commands.CreateOrUpdateMutationMaster;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllDagNoListByLandMasterKhatianType;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllHoldingNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByMouzaId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByOwnerInfoId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId;
using Land.Application.Features.MutationMasterInfo.Queries.GetMutatedLandAmountByLandMasterKhatianTypeDagNo;
using Land.Application.Features.MutationMasterInfo.Queries.GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId;
using Land.Application.Features.MutationMasterInfo.Queries.GetMutationMasterById;
using Land.Application.Features.MutationMasterInfo.Queries.GetSingleLandMutationSummaryByOwnerInfoId;
using Land.Application.Features.MutationMasterInfo.Queries.GetTotalMutatedLand;
using Land.Application.Features.MutationMasterInfo.Queries.GetTotalMutatedLandByLandMasterIdKhatianTypeId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Land.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutationMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MutationMasterController> _logger;

        public MutationMasterController(IMediator mediator, ILogger<MutationMasterController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<GetAllMutationMasterGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllMutationMasterGridQuery() { options = options });
            return Ok(allData);
        }

        
        [HttpPost]
        [Route("CreateOrUpdateMutationMaster")]
        public async Task<ActionResult<string>> Create([FromBody] CreateOrUpdateMutationMasterCommand createOrUpdateMutationMasterCommand)
        {
            try
            {
                var response = await _mediator.Send(createOrUpdateMutationMasterCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to insert Land Information: {ex}");
                return BadRequest("Failed to insert Land Information");
            }
        }

        //Plot Wise Mutation Detail List by MutationMasterId
        [HttpGet("plotWiseMutationDetail/{mutationMasterId}", Name = "GetAllPlotWiseMutationDetailListByMutationMasterId")]
        public async Task<ActionResult<PlotWiseMutationDetailListByMutationMasterIdVm>> GetAllPlotWiseMutationDetailListByMutationMasterId(Guid mutationMasterId)
        {
            var plotWiseMutationDetail = new GetAllPlotWiseMutationDetailListByMutationMasterIdQuery() { MutationMasterId = mutationMasterId };
            var list = await _mediator.Send(plotWiseMutationDetail);
            return Ok(list);
        }

        //Owner Wise Mutation Detail List by MutationMasterId
        [HttpGet("ownerWiseMutationDetail/{mutationMasterId}", Name = "GetAllOwnerWiseMutationDetailListByMutationMasterId")]
        public async Task<ActionResult<OwnerWiseMutationDetailListByMutationMasterIdVm>> GetAllOwnerWiseMutationDetailListByMutationMasterId(Guid mutationMasterId)
        {
            var mutationDetail = new GetAllOwnerWiseMutationDetailListByMutationMasterIdQuery() { MutationMasterId = mutationMasterId };
            var list = await _mediator.Send(mutationDetail);
            return Ok(list);
        }

        [HttpGet("GetAllHoldingNoList", Name = "GetAllHoldingNoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<HoldingNoListVm>>> GetAllHoldingNoList()
        {
            var allHoldingNoNo = await _mediator.Send(new GetAllHoldingNoListQuery());
            return Ok(allHoldingNoNo);
        }

        [HttpGet("{id}", Name = "GetMutationMasterById")]
        public async Task<ActionResult<MutationMasterByIdVm>> GetMutationMasterById(Guid id)
        {
            var mutationMasterById = new GetMutationMasterByIdQuery() { MutationMasterId = id };
            var singleData = await _mediator.Send(mutationMasterById);
            return Ok(singleData);
        }

        [HttpGet("GetTotalMutatedLand", Name = "GetTotalMutatedLand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalMutatedLand()
        {
            var totalMutatedLand = await _mediator.Send(new GetTotalMutatedLandQuery());
            return Ok(totalMutatedLand);
        }

        [HttpGet("TotalMutatedLand/{landMasterId},{khatianTypeId}", Name = "GetTotalMutatedLandByLandMasterIdKhatianTypeId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalMutatedLandByLandMasterIdKhatianTypeId(Guid landMasterId, Guid khatianTypeId)
        {
            var totalMutatedLand = await _mediator.Send(new GetTotalMutatedLandByLandMasterIdKhatianTypeIdQuery() { LandMasterId = landMasterId, KhatianTypeId = khatianTypeId});
            return Ok(totalMutatedLand);
        }

        [HttpGet("mutatedDeedNoList", Name = "GetAllMutatedDeedNoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MutatedDeedNoListVm>>> GetAllMutatedDeedNoList()
        {
            var allDeedNo = new GetAllMutatedDeedNoListQuery();
            var list = await _mediator.Send(allDeedNo);
            return Ok(list);
        }

        [HttpGet("dagNoList/{landMasterId}/{khatianTypeId}", Name = "GetAllDagNoListByLandMasterKhatianType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DagNoListByLandMasterKhatianTypeVm>>> GetAllDagNoListByLandMasterKhatianType(Guid landMasterId, Guid khatianTypeId)
        {
            var dagNoList = new GetAllDagNoListByLandMasterKhatianTypeQuery() { LandMasterId = landMasterId, KhatianTypeId = khatianTypeId };
            var result = await _mediator.Send(dagNoList);
            return Ok(result);
        }

        [HttpGet("totalPlotWiseMutatedLand/{landMasterId}/{khatianTypeId}/{dagNo}", Name = "GetTotalPlotWiseMutatedLandAmountByLandMasterKhatianTypeDagNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalPlotWiseMutatedLandAmountByLandMasterKhatianTypeDagNo(Guid landMasterId, Guid khatianTypeId, string dagNo)
        {
            var data = new GetMutatedLandAmountByLandMasterKhatianTypeDagNoQuery() { LandMasterId = landMasterId, KhatianTypeId = khatianTypeId, DagNo = dagNo };
            var totalMutatedLand = await _mediator.Send(data);
            return Ok(totalMutatedLand);
        }

        [HttpGet("transferedOwnerInfoList/{landMasterId}/{khatianTypeId}", Name = "GetAllTransferedOwnerInfoByLandMasterKhatianTypeId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>>> GetAllTransferedOwnerInfoByLandMasterKhatianTypeId(Guid landMasterId, Guid khatianTypeId)
        {
            var ownerInfoList = new GetAllTransferedOwnerInfoByLandMasterKhatianTypeIdQuery() { LandMasterId = landMasterId, KhatianTypeId = khatianTypeId };
            var result = await _mediator.Send(ownerInfoList);
            return Ok(result);
        }

        [HttpGet("totalOwnerWiseMutatedLand/{landMasterId}/{khatianTypeId}/{ownerInfoId}", Name = "GetTotalOwnerWiseMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalOwnerWiseMutatedLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid landMasterId, Guid khatianTypeId, Guid ownerInfoId)
        {
            var data = new GetMutatedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery() { LandMasterId = landMasterId, KhatianTypeId = khatianTypeId, OwnerInfoId = ownerInfoId };
            var totalMutatedLand = await _mediator.Send(data);
            return Ok(totalMutatedLand);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandMutationSummaryGridByDivisionId/{DivisionId}")]
        public async Task<ActionResult<GridEntity<GetAllLandMutationSummaryByDivisionIdVm>>> GetCSGridList([FromBody] GridOptions options, Guid DivisionId)
        {
            try
            {
                var data = await _mediator.Send(new GetAllLandMutationSummaryByDivisionIdQuery(options, DivisionId));
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryMutationGridByDistrictId/{DistrictId}")]
        public async Task<ActionResult<GridEntity<GetAllLandMutationSummaryByDistrictIdVm>>> GetAllLandSummaryMutationGridByDistrictId([FromBody] GridOptions options, Guid DistrictId)
        {
            try
            {
                var data = await _mediator.Send(new GetAllLandMutationSummaryByDistrictIdQuery(options, DistrictId));
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandMutationSummaryGridByUpozilaId/{UpozilaId}")]
        public async Task<ActionResult<GridEntity<GetAllLandMutationSummaryByUpozilaIdVm>>> GetAllLandMutationSummaryGridByUpozilaId([FromBody] GridOptions options, Guid UpozilaId)
        {
            try
            {
                var data = await _mediator.Send(new GetAllLandMutationSummaryByUpozilaIdQuery(options, UpozilaId));
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandMutationSummaryGridByMouzaId/{mouzaId}")]
        public async Task<ActionResult<GridEntity<GetAllLandMutationSummaryByMouzaIdVm>>> GetAllLandMutationSummaryGridByMouzaId([FromBody] GridOptions options, Guid mouzaId)
        {
            try
            {
                var data = await _mediator.Send(new GetAllLandMutationSummaryByMouzaIdQuery(options, mouzaId));
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandMutationSummaryGridByOwnerId/{mouzaId}/{ownerInfoId}")]
        public async Task<ActionResult<GridEntity<GetAllLandMutationSummaryByOwnerInfoIdVm>>> GetAllLandMutationSummaryGridByOwnerId([FromBody] GridOptions options, Guid? mouzaId,Guid ownerInfoId)
        {
            try
            {
                var data = await _mediator.Send(new GetAllLandMutationSummaryByOwnerInfoIdQuery(options, mouzaId, ownerInfoId));
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetSingleLandMutationSummaryGridByOwnerId/{ownerInfoId}")]
        public async Task<ActionResult<GridEntity<GetAllLandMutationSummaryByOwnerInfoIdVm>>> GetSingleLandMutationSummaryGridByOwnerId([FromBody] GridOptions options, Guid ownerInfoId)
        {
            try
            {
                var data = await _mediator.Send(new GetSingleLandMutationSummaryByOwnerInfoIdQuery(options, ownerInfoId));
                return data;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
