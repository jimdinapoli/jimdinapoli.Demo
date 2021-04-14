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
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var id = await _mediator.Send(createCustomerCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(statusCode:204)]
        [ProducesResponseType(statusCode:404)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }
    }
}
