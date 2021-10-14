using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidataShopping.Application.Customers.GetCustomerOrders
{
    public class CustomerOrdersDto
    {
        public Guid OrderId { get; set; }
        public string Title { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
