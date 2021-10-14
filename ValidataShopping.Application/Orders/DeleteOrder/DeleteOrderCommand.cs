using ValidataShopping.Application.Configuration.Commands;
using System;

namespace ValidataShopping.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommand : ICommand
    {
        public DeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}
