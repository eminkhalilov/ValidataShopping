using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Orders;
using ValidataShopping.Domain.Products;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Application.Orders.CreateOrderProduct
{
    public class CreateOrderProductHandler : ICommandHandler<CreateOrderProductCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderProductHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateOrderProductCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrder(command.OrderId);
            var product = await _productRepository.GetProduct(command.ProductId);
            order.AddProduct(product, command.Quantity);

            return order.OrderId;
        }
    }
}
