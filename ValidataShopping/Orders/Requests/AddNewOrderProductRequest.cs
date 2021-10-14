using System;

namespace ValidataShopping.API.Orders.Requests
{
    public class AddNewOrderProductRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
