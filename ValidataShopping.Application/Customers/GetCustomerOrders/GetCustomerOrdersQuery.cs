using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Queries;

namespace ValidataShopping.Application.Customers.GetCustomerOrders
{
    public class GetCustomerOrdersQuery : IQuery<IEnumerable<CustomerOrdersDto>>
    {
        public GetCustomerOrdersQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; private set; }
    }
}
