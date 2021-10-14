using MediatR;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Orders;
using ValidataShopping.Domain.Products;
using ValidataShopping.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ValidataShopping.Domain.Customers;

namespace ValidataShopping.Application.Service
{
    public class PopulateDbHandler : ICommandHandler<PopulateDbCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<string> _productNames = new List<string>() { "Butter", "Bread" };
        private readonly string _orderName = "Shopping";
        public PopulateDbHandler(
            IOrderRepository validataShoppingContext,
            IProductRepository productRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = validataShoppingContext;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(PopulateDbCommand request, CancellationToken cancellationToken)
        {
            List<Product> newProducts = new List<Product>();
            var newCustomer = new Customer { Name = "Test Customer", Address = "Test Address", PostalCode = "CODE1234" };

            bool anyProductExists = await _productRepository.AnyAsync();
            if (anyProductExists)
            {
                throw new InvalidOperationException();
            }

            newProducts = CreateProducts();
            await _productRepository.AddRangeAsync(newProducts);
            var _customerId = await _customerRepository.AddAsync(newCustomer);
            Order order = Order.Create(_orderName, _customerId);
            AddProductsToOrder(newProducts, order);

            await _orderRepository.AddAsync(order);
            return Unit.Value;
        }

        private static void AddProductsToOrder(List<Product> newProducts, Order order)
        {
            foreach (Product product in newProducts)
            {
                order.AddProduct(product, 2);
            }
        }

        private List<Product> CreateProducts()
        {
            List<Product> newProducts = new List<Product>();
            foreach (string name in _productNames)
            {
                newProducts.Add(Product.Create(name));
            }

            return newProducts;
        }
    }
}
