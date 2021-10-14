using ValidataShopping.Domain.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ValidataShopping.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(Guid orderId);
        Task<bool> AnyAsync();
        Task AddAsync(Order order);
        Task DeleteOrder(Guid orderId);
    }
}
