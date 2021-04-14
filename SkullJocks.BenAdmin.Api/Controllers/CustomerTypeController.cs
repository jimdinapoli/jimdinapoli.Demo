using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType;
using SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeList;
using SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeListWithCustomers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCustomerTypes")]
        [ProducesResponseType(statusCode:200)]
        public async Task<ActionResult<List<CustomerTypeListViewModel>>> GetAllCustomerTypes()
        {
            var dtos = await _mediator.Send(new GetCustomerTypeListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithcustomers", Name = "GetCustomerTypesIncludingCustomers")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(statusCode: 200)]
        public async Task<ActionResult<CustomerTypeListViewModel>> GetAllCustomerTypesIncludingCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomerTypesIncludingCustomersQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCustomerType")]
        public async Task<ActionResult<CreateCustomerTypeCommandResponse>> Create([FromBody] CreateCustomerTypeCommand createCustomerTypeCommand)
        {
            var response = await _mediator.Send(createCustomerTypeCommand);
            return Ok(response);
        }
    }
}
