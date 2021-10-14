using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValidataShopping.API.Orders.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidataShopping.Application.Orders.GetOrders;
using ValidataShopping.Application.Orders.GetOrderDetails;
using ValidataShopping.Application.Orders.UpdateOrderDetails;
using ValidataShopping.Application.Orders.UpdateOrderProduct;
using ValidataShopping.Application.Orders.DeleteOrder;
using ValidataShopping.Application.Orders.DeleteOrderProduct;
using ValidataShopping.Application.Orders.CreateOrderProduct;
using ValidataShopping.Application.Orders.CreateOrder;

namespace ValidataShopping.API.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrders()
        {
            IEnumerable<Application.Orders.GetOrders.OrderDto> orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute]Guid orderId)
        {
            Application.Orders.GetOrderDetails.OrderDto result = await _mediator.Send(new GetOrderDetailsQuery(orderId));
            return Ok(result);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrderDetails(
            [FromRoute]Guid orderId, 
            [FromBody]OrderRequest orderRequest)
        {
            UpdateOrderDetailsCommand command = new UpdateOrderDetailsCommand(orderId, orderRequest.Title);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{orderId}/order-product/{orderProductId}")]
        public async Task<IActionResult> UpdateOrderProduct(
            [FromRoute]Guid orderId,
            [FromRoute]Guid orderProductId,
            [FromBody]UpdateOrderProductRequest updateOrderProductRequest)
        {
            UpdateOrderProductCommand command = new UpdateOrderProductCommand(orderId, orderProductId, updateOrderProductRequest.Purchased);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder([FromRoute]Guid orderId)
        {
            await _mediator.Send(new DeleteOrderCommand(orderId));
            return Ok();
        }

        [HttpDelete("{orderId}/order-product/{orderProductId}")]
        public async Task<IActionResult> DeleteOrderProduct(
            [FromRoute]Guid orderId,
            [FromRoute]Guid orderProductId)
        {
            DeleteOrderProductCommand command = new DeleteOrderProductCommand(orderId, orderProductId);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("{orderId}/order-product")]
        public async Task<IActionResult> AddNewOrderProduct(
            [FromRoute]Guid orderId,
            [FromBody]AddNewOrderProductRequest request)
        {
            await _mediator.Send(new CreateOrderProductCommand(orderId, request.ProductId, request.Quantity));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder([FromBody] CreateNewOrderRequest createNewOrderRequest)
        {
            await _mediator.Send(new CreateNewOrderCommand(createNewOrderRequest.OrderName, createNewOrderRequest.CustomerId));
            return Ok();
        }
    }   
}