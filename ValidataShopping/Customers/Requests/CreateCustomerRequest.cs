using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidataShopping.API.Customers.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
