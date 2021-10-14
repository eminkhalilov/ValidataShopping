using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Commands;

namespace ValidataShopping.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : ICommand
    {
        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; private set; }
    }
}
