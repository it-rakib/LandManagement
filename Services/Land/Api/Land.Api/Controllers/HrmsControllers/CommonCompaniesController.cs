using MediatR;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetCompanyNameById;
using Merchandising.Domain.HrmsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchandising.Api.Controllers.HrmsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonCompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommonCompaniesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("all", Name = "GetAllCommonCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CommonCompany>>> GetAll()
        {
            var list = await _mediator.Send(new GetAllCommonCompanyListQuery());
            return Ok(list);
        }
        [HttpGet("{id}", Name = "GetCompanyNameById")]
        public async Task<ActionResult<CompanyNameByIdVm>> GetById(int id)
        {
            var getByIdQuery = new GetCompanyNameByIdQuery() { Id = id };
            var list = await _mediator.Send(getByIdQuery);
            return Ok(list);
        }
    }
}
