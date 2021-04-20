using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkullJocks.BenAdmin.Application.Features.Customers.Commands.CreateCustomer;
using SkullJocks.BenAdmin.Application.Features.Customers.Commands.UpdateCustomer;
using SkullJocks.BenAdmin.Application.Features.Customers.Queries.GetCustomerDetails;
using SkullJocks.BenAdmnin.Application.Features.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCustomers")]
        [ProducesResponseType(statusCode:200)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerListModel>>> GetAllCustomers()
        {
            var result = await _mediator.Send(new GetCustomerListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerDetailsViewModel>> GetCustomerById(Guid id)
        {
            var getCustomerDetailsQuery = new GetCustomerDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(getCustomerDetailsQuery));
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<CreateCustomerCommandResponse>> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var response = await _mediator.Send(createCustomerCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCustomer")]
        public async Task<ActionResult<UpdateCustomerCommandResponse>> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var response = await _mediator.Send(updateCustomerCommand);
            return Ok(response);
        }
    }
}
