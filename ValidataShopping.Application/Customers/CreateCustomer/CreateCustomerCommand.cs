using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Commands;

namespace ValidataShopping.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand(string name, string address, string postalCode)
        {
            Name = name;
            Address = address;
            PostalCode = postalCode;

        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
