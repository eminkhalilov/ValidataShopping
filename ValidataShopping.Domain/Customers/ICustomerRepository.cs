using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidataShopping.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(Guid customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Guid> AddAsync(Customer customer);
        Task DeleteCustomer(Guid customerId);
    }
}
