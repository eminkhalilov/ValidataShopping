using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Domain.Orders;
using ValidataShopping.Domain.SeedWork;

namespace ValidataShopping.Domain.Customers
{
    public class Customer : IAggregateRoot
    {
        public Guid CustomerId { get; private set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }

        private List<Order> _orders;
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
        public static Customer Create(string name, string address, string postalCode)
        {
            return new Customer() { Name = name, Address = address, PostalCode = postalCode };
        }
    }
}
