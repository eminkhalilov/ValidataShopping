using MediatR;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Application.Orders.DeleteOrderProduct
{
    public class DeleteOrderProductHandler : ICommandHandler<DeleteOrderProductCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderProductHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderProductCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrder(command.OrderId);
            order.DeleteProduct(command.OrderProductId);
            return Unit.Value;
        }
    }
}
