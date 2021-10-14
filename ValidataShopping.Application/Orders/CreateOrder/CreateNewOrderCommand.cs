using System;
using ValidataShopping.Application.Configuration.Commands;

namespace ValidataShopping.Application.Orders.CreateOrder
{
    public class CreateNewOrderCommand : ICommand
    {
        public CreateNewOrderCommand(string orderName, Guid customerId)
        {
            OrderName = orderName;
            CustomerId = customerId;

        }

        public string OrderName { get; private set; }
        public Guid CustomerId { get; set; }
    }
}
