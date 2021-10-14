using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Commands;

namespace ValidataShopping.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand : ICommand
    {
        public UpdateCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; set; }
    }
}
