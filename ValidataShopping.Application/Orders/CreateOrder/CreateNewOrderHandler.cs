using MediatR;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Orders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Application.Orders.CreateOrder
{
    public class CreateNewOrderHandler : ICommandHandler<CreateNewOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateNewOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Create(request.OrderName, request.CustomerId);
            await _orderRepository.AddAsync(order);
            return Unit.Value;
        }
    }
}
