using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Domain.Customers;
using ValidataShopping.Infrastructure.SqlServer.Database;

namespace ValidataShopping.Infrastructure.Domain.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ValidataShoppingContext _validataShoppingContext;
        public CustomerRepository(ValidataShoppingContext validataShoppingContext)
        {
            _validataShoppingContext = validataShoppingContext ?? throw new ArgumentNullException(nameof(validataShoppingContext)); ;
        }
        public async Task<Guid> AddAsync(ValidataShopping.Domain.Customers.Customer customer)
        {
           await _validataShoppingContext.Customers.AddAsync(customer);
            return customer.CustomerId;
        }

        public async Task DeleteCustomer(Guid customerId)
        {
            var customer = await _validataShoppingContext.Customers.SingleOrDefaultAsync(x => x.CustomerId == customerId);
            _validataShoppingContext.Customers.Remove(customer);
        }

        public async Task<IEnumerable<ValidataShopping.Domain.Customers.Customer>> GetAllAsync()
        {
            return await _validataShoppingContext.Customers.ToListAsync();
        }

        public async Task<ValidataShopping.Domain.Customers.Customer> GetCustomer(Guid customerId)
        {
            return await _validataShoppingContext.Customers
                .SingleOrDefaultAsync(x => x.CustomerId == customerId);
        }
    }
}
