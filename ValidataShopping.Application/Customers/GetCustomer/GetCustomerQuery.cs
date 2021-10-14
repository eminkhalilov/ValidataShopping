using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Queries;

namespace ValidataShopping.Application.Customers.GetCustomer
{
    public class GetCustomerQuery : IQuery<CustomerDto>
    {
        public GetCustomerQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; private set; }
    }
}
