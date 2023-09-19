using MediatR;
using Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchandising.Api.Controllers.HrmsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganogramsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganogramsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAllSupervisorByEmpId/{empid}")]
        public async Task<ActionResult<GetSupervisorByEmpIdResponse>> GetAllSupervisorByEmpId(long empid)
        {
            GetSupervisorByEmpIdResponse response = new();
            try
            {
                var req = new GetSupervisorByEmpIdQuery() { EmpID = empid };
                response = await _mediator.Send(req);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return Ok(response);
        }

        //[HttpGet("{id}", Name = "GetAgentById")]
        //public async Task<ActionResult<AgentListByIdVm>> GetById(Guid id)
        //{
        //    var getAgentListByIdQuery = new GetAgentListByIdQuery() { AgentId = id };
        //    var list = await _mediator.Send(getAgentListByIdQuery);
        //    return Ok(list);
        //}
    }
}
