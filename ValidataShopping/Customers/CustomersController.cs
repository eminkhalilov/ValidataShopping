using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataShopping.API.Customers.Requests;
using ValidataShopping.Application.Customers.CreateCustomer;
using ValidataShopping.Application.Customers.DeleteCustomer;
using ValidataShopping.Application.Customers.GetAllCustomers;
using ValidataShopping.Application.Customers.GetCustomer;
using ValidataShopping.Application.Customers.GetCustomerOrders;
using ValidataShopping.Application.Customers.UpdateCustomer;

namespace ValidataShopping.API.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        [Authorize]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(customerId));
            return Ok(customer);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
        }

        [HttpGet("{customerId}/orders")]
        [Authorize]
        public async Task<IActionResult> GetCustomerOrders([FromRoute] Guid customerId)
        {
            var customers = await _mediator.Send(new GetCustomerOrdersQuery(customerId));
            return Ok(customers);
        }


        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update([FromRoute] Guid customerId)
        {
            var command = new UpdateCustomerCommand(customerId);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid customerId)
        {
            await _mediator.Send(new DeleteCustomerCommand(customerId));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            await _mediator.Send(new CreateCustomerCommand(
                createCustomerRequest.Name,
                createCustomerRequest.Address,
                createCustomerRequest.PostalCode));
            return Ok();
        }
    }
}
