using System;

namespace ValidataShopping.API.Orders.Requests
{
    public class CreateNewOrderRequest
    {
        public string OrderName { get; set; }
        public Guid CustomerId { get; set; }
    }
}
