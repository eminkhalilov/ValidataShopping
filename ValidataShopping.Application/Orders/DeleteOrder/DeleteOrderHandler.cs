using MediatR;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Orders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Application.Orders.DeleteOrder
{
    public class DeleteOrderHandler : ICommandHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteOrder(command.OrderId);
            return Unit.Value;
        }
    }
}
