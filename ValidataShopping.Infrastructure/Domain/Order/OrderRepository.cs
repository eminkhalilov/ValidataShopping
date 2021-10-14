using Microsoft.EntityFrameworkCore;
using ValidataShopping.Domain.Orders;
using ValidataShopping.Infrastructure.SqlServer.Database;
using ValidataShopping.Infrastructure.SqlServer.SeedWork;
using ValidataShopping.Infrastructure.SqlServer.TypesConfigurations;
using System;
using System.Threading.Tasks;

namespace ValidataShopping.Infrastructure.SqlServer.Domain.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ValidataShoppingContext _validataShoppingContext;

        public OrderRepository(ValidataShoppingContext validataShoppingContext)
        {
            _validataShoppingContext = validataShoppingContext ?? throw new ArgumentNullException(nameof(validataShoppingContext)); ;
        }

        public async Task AddAsync(ValidataShopping.Domain.Orders.Order order)
        {
            await _validataShoppingContext.Orders.AddAsync(order);
        }

        public async Task<bool> AnyAsync()
        {
            return await _validataShoppingContext.Orders.AnyAsync();
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var order = await _validataShoppingContext.Orders.SingleOrDefaultAsync(x => x.OrderId == orderId);
            _validataShoppingContext.Orders.Remove(order);
        }

        public async Task<ValidataShopping.Domain.Orders.Order> GetOrder(Guid orderId)
        {
            return await _validataShoppingContext.Orders
                .SingleOrDefaultAsync(x => x.OrderId == orderId);
        }
    }
}
