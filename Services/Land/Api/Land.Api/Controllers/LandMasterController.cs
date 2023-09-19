using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster;
using Land.Application.Features.LandMasterInfo.Queries.GetAllBayaDeedDetailListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoByOwnerInfoId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoList;
using Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoListByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterIdMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandDetailListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandMasterGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandOwnerListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSalerInfoListByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByUpozilaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictByDistrictId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictList;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryFileDeedOwnerCommonGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByUpozilaIdGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryOwnerMouzaCommonGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpazilaByUpazilaId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaByDistrictIdGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaGrid;
using Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandSaleDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandTransferDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandSaleDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandTransferDetailByLandMasterId;
using Land.Application.Features.LandMasterInfo.Queries.GetAllUpozilaByDistrictIdList;
using Land.Application.Features.LandMasterInfo.Queries.GetLandAmountByLandMasterIdMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetLandInformationsByDeedNo;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByMouzaId;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId;
using Land.Application.Features.LandMasterInfo.Queries.GetLandSummarySingleGridByOwnerId;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalDeed;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalDistrict;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalLandAmount;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalLandPurchaseAmount;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalMouza;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo;
using Land.Application.Features.LandMasterInfo.Queries.GetTotalUpozila;
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
    public class LandMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LandMasterController> _logger;

        public LandMasterController(IMediator mediator, ILogger<LandMasterController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("CreateOrUpdateLandMaster")]
        public async Task<ActionResult<string>> Create([FromBody] CreateOrUpdateLandMasterCommand  createOrUpdateLandMasterCommand)
        {
            try
            {
                var response = await _mediator.Send(createOrUpdateLandMasterCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to insert Land Information: {ex}");
                return BadRequest("Failed to insert Land Information");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridData")]
        public async Task<ActionResult<List<GetAllLandMasterGridVm>>> GetAllGridData([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandMasterGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpGet("plotWiseLandSaleDetail/{landMasterId}", Name = "GetAllPlotWiseLandSaleDetailByLandMasterId")]
        public async Task<ActionResult<PlotWiseLandSaleDetailByLandMasterIdVm>> GetAllPlotWiseLandSaleDetailByLandMasterId(Guid landMasterId)
        {
            var plotWiseLandDetail = new GetAllPlotWiseLandSaleDetailByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(plotWiseLandDetail);
            return Ok(list);
        }

        [HttpGet("ownerWiseLandSaleDetail/{landMasterId}", Name = "GetAllOwnerWiseLandSaleDetailByLandMasterId")]
        public async Task<ActionResult<OwnerWiseLandSaleDetailByLandMasterIdVm>> GetAllOwnerWiseLandSaleDetailByLandMasterId(Guid landMasterId)
        {
            var ownerWiseLandDetail = new GetAllOwnerWiseLandSaleDetailByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(ownerWiseLandDetail);
            return Ok(list);
        }


        [HttpGet("plotWiseLandTransferDetail/{landMasterId}", Name = "GetAllPlotWiseLandTransferDetailByLandMasterId")]
        public async Task<ActionResult<PlotWiseLandTransferDetailByLandMasterIdVm>> GetAllPlotWiseLandTransferDetailByLandMasterId(Guid landMasterId)
        {
            var plotWiseLandTransferDetail = new GetAllPlotWiseLandTransferDetailByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(plotWiseLandTransferDetail);
            return Ok(list);
        }

        [HttpGet("ownerWiseLandTransferDetail/{landMasterId}", Name = "GetAllOwnerWiseLandTransferDetailByLandMasterId")]
        public async Task<ActionResult<OwnerWiseLandTransferDetailByLandMasterIdVm>> GetAllOwnerWiseLandTransferDetailByLandMasterId(Guid landMasterId)
        {
            var ownerWiseLandTransferDetail = new GetAllOwnerWiseLandTransferDetailByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(ownerWiseLandTransferDetail);
            return Ok(list);
        }

        [HttpGet("salerInfo/{landMasterId}", Name = "GetAllLandSalerInfoListByLandMasterId")]
        public async Task<ActionResult<LandSalerInfoListByLandMasterIdVm>> GetAllLandSalerInfoListByLandMasterId(Guid landMasterId)
        {
            var landSalerInfo = new GetAllLandSalerInfoListByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(landSalerInfo);
            return Ok(list);
        }

        //Khatian Detail List
        [HttpGet("khatianDetails/{landMasterId}", Name = "GetAllKhatianDetailListByLandMasterId")]
        public async Task<ActionResult<KhatianDetailListByLandMasterIdVm>> GetAllKhatianDetailListByLandMasterId(Guid landMasterId)
        {
            var landDetail = new GetAllKhatianDetailListByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(landDetail);
            return Ok(list);
        }

        //Khatian Detail List By Land Master and Mouza Id & KhatianTypeId
        [HttpGet("khatianDetails/{landMasterId},{mouzaId},{khatianTypeId}", Name = "GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId")]
        public async Task<ActionResult<KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm>> GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId(Guid landMasterId, Guid mouzaId, Guid khatianTypeId)
        {
            var landDetail = new GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdQuery() { LandMasterId = landMasterId, MouzaId = mouzaId, KhatianTypeId = khatianTypeId };
            var list = await _mediator.Send(landDetail);
            return Ok(list);
        }

        //Khatian Type List By Land Master and Mouza Id
        [HttpGet("khatianTypes/{landMasterId},{mouzaId}", Name = "GetAllKhatianTypeListByLandMasterIdMouzaId")]
        public async Task<ActionResult<KhatianTypeListByLandMasterIdMouzaIdVm>> GetAllKhatianTypeListByLandMasterIdMouzaId(Guid landMasterId, Guid mouzaId)
        {
            var khatianTypes = new GetAllKhatianTypeListByLandMasterIdMouzaIdQuery() { LandMasterId = landMasterId, MouzaId = mouzaId };
            var list = await _mediator.Send(khatianTypes);
            return Ok(list);
        }

        //Khatian Type List By Land Master
        [HttpGet("khatianTypes/{landMasterId}", Name = "GetAllKhatianTypeListByLandMasterId")]
        public async Task<ActionResult<KhatianTypeListByLandMasterIdVm>> GetAllKhatianTypeListByLandMasterId(Guid landMasterId)
        {
            var khatianTypes = new GetAllKhatianTypeListByLandMasterIdQuery() { LandMasterId = landMasterId};
            var list = await _mediator.Send(khatianTypes);
            return Ok(list);
        }

        //Land Owner Detail List
        [HttpGet("landOwner/{landMasterId}", Name = "GetAllLandOwnerListByLandMasterId")]
        public async Task<ActionResult<LandOwnerListByLandMasterIdVm>> GetAllLandOwnerListByLandMasterId(Guid landMasterId)
        {
            var landOwner = new GetAllLandOwnerListByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(landOwner);
            return Ok(list);
        }

        //Baya Deed Detail List
        [HttpGet("bayaDeedDetail/{landMasterId}", Name = "GetAllBayaDeedDetailListByLandMasterId")]
        public async Task<ActionResult<BayaDeedDetailListByLandMasterIdVm>> GetAllBayaDeedDetailListByLandMasterId(Guid landMasterId)
        {
            var bayaDeeds = new GetAllBayaDeedDetailListByLandMasterIdQuery() { LandMasterId = landMasterId };
            var list = await _mediator.Send(bayaDeeds);
            return Ok(list);
        }


        [HttpGet("deedNoList/{mouzaId}", Name = "GetDeedNoListByMouzaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DeedNoListByMouzaIdVm>>> GetDeedNoListByMouzaId(Guid mouzaId)
        {
            var allDeedNo = new GetAllDeedNoListByMouzaIdQuery() { MouzaId = mouzaId };
            var list = await _mediator.Send(allDeedNo);
            return Ok(list);
        }

        [HttpGet("allDeedNoList", Name = "GetAllDeedNoList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AllDeedNoListVm>>> GetAllDeedNoList()
        {
            var allDeedNo = new GetAllDeedNoListQuery();
            var list = await _mediator.Send(allDeedNo);
            return Ok(list);
        }

        [HttpGet("totalLandAmount/{landMasterId},{mouzaId}", Name = "GetLandAmountByLandMasterIdMouzaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetLandAmountByLandMasterIdMouzaId(Guid landMasterId,Guid mouzaId)
        {
            var totalLandAmount = new GetLandAmountByLandMasterIdMouzaIdQuery() { LandMasterId = landMasterId, MouzaId =  mouzaId};
            //var totalLandAmount = new GetLandAmountByLandMasterIdMouzaIdQuery() { LandMasterId = landMasterId};
            var data = await _mediator.Send(totalLandAmount);
            return Ok(data);
        }

        [HttpGet("GetTotalLandAmount", Name = "GetTotalLandAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalLandAmount()
        {
            var totalLandAmount = await _mediator.Send(new GetTotalLandAmountQuery());
            return Ok(totalLandAmount);
        }

        [HttpGet("GetTotalLandPurchaseAmount", Name = "GetTotalLandPurchaseAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalLandPurchaseAmount()
        {
            var totalLandPurchaseAmount = await _mediator.Send(new GetTotalLandPurchaseAmountQuery());
            return Ok(totalLandPurchaseAmount);
        }

        [HttpGet("GetTotalDeed", Name = "GetTotalDeed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> GetTotalDeed()
        {
            var totalDeed = await _mediator.Send(new GetTotalDeedQuery());
            return Ok(totalDeed);
        }

        [HttpGet("GetTotalDistrict", Name = "GetTotalDistrict")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> GetTotalDistrict()
        {
            var totalDistrict = await _mediator.Send(new GetTotalDistrictQuery());
            return Ok(totalDistrict);
        }

        [HttpGet("GetTotalUpozila", Name = "GetTotalUpozila")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> GetTotalUpozila()
        {
            var totalUpozila = await _mediator.Send(new GetTotalUpozilaQuery());
            return Ok(totalUpozila);
        }

        [HttpGet("GetTotalMouza", Name = "GetTotalMouza")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> GetTotalMouza()
        {
            var totalMouza = await _mediator.Send(new GetTotalMouzaQuery());
            return Ok(totalMouza);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllGridDataLandSummaryDistrict")]
        public async Task<ActionResult<List<GetAllLandSummaryDistrictGridVm>>> GetAllGridDataLandSummaryDistrict([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryDistrictGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpGet("LandSummaryDistrictSingle/{districtId}", Name = "GetAllLandSummaryDistrictByDistrictId")]
        public async Task<ActionResult<LandSummaryDistrictByDistrictIdVm>> GetAllLandSummaryDistrictByDistrictId(Guid districtId)
        {
            var data = new GetAllLandSummaryDistrictByDistrictIdQuery() { DistrictId = districtId };
            var list = await _mediator.Send(data);
            return Ok(list);
        }

        [HttpGet("GetAllLandSummaryDistrictList", Name = "GetAllLandSummaryDistrictList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllLandSummaryDistrictListVm>>> GetAllLandSummaryDistrictList()
        {
            var list = await _mediator.Send(new GetAllLandSummaryDistrictListQuery());
            return Ok(list);
        }

        [HttpGet("upozila/{districtId}", Name = "GetAllUpozilaByDistrictId")]
        public async Task<ActionResult<GetAllUpozilaByDistrictIdListVm>> GetAllUpozilaByDistrictId(Guid districtId)
        {
            var upozilaList = new GetAllUpozilaByDistrictIdListQuery() { DistrictId = districtId };
            var list = await _mediator.Send(upozilaList);
            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryUpozilaGridAsync")]
        public async Task<ActionResult<List<LandSummaryUpozilaGridVm>>> GetAllLandSummaryUpozilaGridAsync([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryUpozilaGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpGet("GetAllLandSummaryUpazila/{upozilaId}", Name = "GetAllLandSummaryUpazilaByUpazilaId")]
        public async Task<ActionResult<LandSummaryUpazilaByUpazilaIdVm>> GetAllLandSummaryUpazilaByUpazilaId(Guid upozilaId)
        {
            var data = new GetAllLandSummaryUpazilaByUpazilaIdQuery() { UpozilaId = upozilaId };
            var list = await _mediator.Send(data);
            return Ok(list);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryMouzaGridAsync")]
        public async Task<ActionResult<List<LandSummaryMouzaGridVm>>> GetAllLandSummaryMouzaGridAsync([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryMouzaGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpGet("GetAllLandSummaryMouza/{mouzaId}", Name = "GetAllLandSummaryMouzaByMouzaId")]
        public async Task<ActionResult<LandSummaryMouzaByMouzaIdVm>> GetAllLandSummaryMouzaByMouzaId(Guid mouzaId)
        {
            var data = new GetAllLandSummaryMouzaByMouzaIdQuery() { MouzaId = mouzaId };
            var list = await _mediator.Send(data);
            return Ok(list);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryOwnerMouzaCommonGrid")]
        public async Task<ActionResult<List<GetAllLandSummaryOwnerMouzaCommonGridVm>>> GetAllLandSummaryOwnerMouzaCommonGrid([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryOwnerMouzaCommonGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryFileDeedOwnerCommonGrid")]
        public async Task<ActionResult<List<GetAllLandSummaryFileDeedOwnerCommonGridVm>>> GetAllLandSummaryFileDeedOwnerCommonGrid([FromBody] GridOptions options)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryFileDeedOwnerCommonGridQuery() { options = options });
            return Ok(allData);
        }

        [HttpGet("getDeedNoList/{ownerInfoId}", Name = "GetAllDeedNoByOwnerInfoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DeedNoByOwnerInfoIdVm>>> GetAllDeedNoByOwnerInfoId(Guid ownerInfoId)
        {
            var allDeedNo = new GetAllDeedNoByOwnerInfoIdQuery() { OwnerInfoId = ownerInfoId };
            var list = await _mediator.Send(allDeedNo);
            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryUpozilaByDistrictIdGridAsync/{districtId}")]
        public async Task<ActionResult<List<LandSummaryUpozilaByDistrictIdGridVm>>> GetAllLandSummaryUpozilaByDistrictIdGridAsync([FromBody] GridOptions options, Guid districtId)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryUpozilaByDistrictIdGridQuery() { options = options , DistrictId = districtId});
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryMouzaByUpozilaIdGridAsync/{upozilaId}")]
        public async Task<ActionResult<List<LandSummaryMouzaByUpozilaIdGridVm>>> GetAllLandSummaryMouzaByUpozilaIdGridAsync([FromBody] GridOptions options, Guid upozilaId)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryMouzaByUpozilaIdGridQuery() { options = options, UpozilaId = upozilaId });
            return Ok(allData);
        }

        [HttpGet("totalPlotWiseTransferedLandAmount/{transferedLandMasterId}/{transferedKhatianTypeId}/{transferedDagNo}", Name = "GetTotalTransferedLandAmountByLandMasterKhatianTypeDagNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNo(Guid transferedLandMasterId, Guid transferedKhatianTypeId, int transferedDagNo)
        {
            var data = new GetTotalPlotWiseTransferedLandAmountByLandMasterKhatianTypeDagNoQuery() { TransferedLandMasterId = transferedLandMasterId, TransferedKhatianTypeId = transferedKhatianTypeId, TransferedDagNo = transferedDagNo };
            var totalTransferedLandAmount = await _mediator.Send(data);
            return Ok(totalTransferedLandAmount);
        }

        [HttpGet("totalOwnerWiseTransferedLandAmount/{transferedLandMasterId}/{transferedKhatianTypeId}/{transferedOwnerInfoId}", Name = "GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid transferedLandMasterId, Guid transferedKhatianTypeId, Guid transferedOwnerInfoId)
        {
            var data = new GetTotalOwnerWiseTransferedLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery() { TransferedLandMasterId = transferedLandMasterId, TransferedKhatianTypeId = transferedKhatianTypeId, TransferedOwnerInfoId = transferedOwnerInfoId };
            var totalTransferedLandAmount = await _mediator.Send(data);
            return Ok(totalTransferedLandAmount);
        }

        [HttpGet("totalPlotWiseSaleLandAmount/{saleLandMasterId}/{saleKhatianTypeId}/{saleDagNo}", Name = "GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNo(Guid saleLandMasterId, Guid saleKhatianTypeId, int saleDagNo)
        {
            var data = new GetTotalPlotWiseSaleLandAmountByLandMasterKhatianTypeDagNoQuery() { SaleLandMasterId = saleLandMasterId, SaleKhatianTypeId = saleKhatianTypeId, SaleDagNo = saleDagNo };
            var totalTransferedLandAmount = await _mediator.Send(data);
            return Ok(totalTransferedLandAmount);
        }

        [HttpGet("totalOwnerWiseSaleLandAmount/{saleLandMasterId}/{saleKhatianTypeId}/{saleOwnerInfoId}", Name = "GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<decimal>> GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoId(Guid saleLandMasterId, Guid saleKhatianTypeId, Guid saleOwnerInfoId)
        {
            var data = new GetTotalOwnerWiseSaleLandAmountByLandMasterKhatianTypeOwnerInfoIdQuery() { SaleLandMasterId = saleLandMasterId, SaleKhatianTypeId = saleKhatianTypeId, SaleOwnerInfoId = saleOwnerInfoId };
            var totalTransferedLandAmount = await _mediator.Send(data);
            return Ok(totalTransferedLandAmount);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryGridByDivisionId/{divisionId}")]
        public async Task<ActionResult<GridEntity<GetAllLandSummaryByDivisionIdVm>>> GetAllLandSummaryGridByDivisionId([FromBody] GridOptions options, Guid divisionId)
        {
            var allData = await _mediator.Send(new GetLandSummaryByDivisionIdQuery()
            {
                options = options,
                DivisionId = divisionId
            });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryGridByDistrictId/{districtId}")]
        public async Task<ActionResult<GridEntity<GetLandSummaryByDistrictIdVm>>> GetAllLandSummaryGridByDistrictId([FromBody] GridOptions options, Guid districtId)
        {
            var allData = await _mediator.Send(new GetLandSummaryByDistrictIdQuery()
            {
                options = options,
                DistrictId = districtId
            });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryGridByUpozilaId/{upozilaId}")]
        public async Task<ActionResult<GridEntity<GetAllLandSummaryByUpozilaIdVm>>> GetAllLandSummaryGridByUpozilaId([FromBody] GridOptions options, Guid upozilaId)
        {
            var allData = await _mediator.Send(new GetAllLandSummaryByUpozilaIdQuery()
            {
                options = options,
                UpozilaId = upozilaId
            });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryGridByMouzaId/{mouzaId}")]
        public async Task<ActionResult<GridEntity<GetLandSummaryByMouzaIdVm>>> GetAllLandSummaryGridByMouzaId([FromBody] GridOptions options, Guid mouzaId)
        {
            var allData = await _mediator.Send(new GetLandSummaryByMouzaIdQuery()
            {
                options = options,
                MouzaId = mouzaId
            });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetAllLandSummaryGridByOwnerId/{mouzaId}/{ownerInfoId}")]
        public async Task<ActionResult<GridEntity<GetLandSummaryByOwnerIdVm>>> GetAllLandSummaryGridByOwnerId([FromBody] GridOptions options,Guid? mouzaId, Guid ownerInfoId)
        {
            var allData = await _mediator.Send(new GetLandSummaryByOwnerIdQuery()
            {
                options = options,
                MouzaId = (Guid)mouzaId,
                OwnerInfoId = ownerInfoId                
            });
            return Ok(allData);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetLandSummarySingleGridByOwnerId/{ownerInfoId}")]
        public async Task<ActionResult<GridEntity<GetLandSummaryByOwnerIdVm>>> GetLandSummarySingleGridByOwnerId([FromBody] GridOptions options, Guid ownerInfoId)
        {
            var allData = await _mediator.Send(new GetSingleLandSummaryByOwnerIdQuery()
            {
                options = options,
                OwnerInfoId = ownerInfoId
            });
            return Ok(allData);
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesDefaultResponseType]
        //[Route("GetAllLandSummaryGlobalGrid")]
        //public async Task<ActionResult<List<GetLandInfoGlobalSearchVm>>> GetAllLandSummaryGlobalGrid([FromBody] GridOptions options)
        //{
        //    var allData = await _mediator.Send(new GetLandInfoGlobalSearchQuery() { options = options });
        //    return Ok(allData);
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Route("GetLandInformationsByDeedNo/{deedNo}")]
        public async Task<ActionResult<List<GetLandInformationsByDeedNoVm>>> GetLandInformationsByDeedNo([FromBody] GridOptions options, string deedNo)
        {
            var allData = await _mediator.Send(new GetLandInformationsByDeedNoQuery() 
            { 
                options = options, 
                DeedNo = deedNo
            });
            return Ok(allData);
        }
    }
}
