using ValidataShopping.Domain.Products;
using ValidataShopping.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using ValidataShopping.Domain.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidataShopping.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        [ForeignKey("Customers")]
        public Guid CustomerId { get; private set; }
        public string Title { get; private set; }
        public DateTime OrderDate { get; private set; }

        private List<OrderProduct> _orderProducts;
        public IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts.AsReadOnly();

        private Order()
        {
            _orderProducts = new List<OrderProduct>();
        }

        public static Order Create(string orderTitle, Guid customerId)
        {
            return new Order() { Title = orderTitle, CustomerId = customerId, OrderDate = DateTime.Now };
        }

        public void AddProduct(Product product, int quantity)
        {
            _orderProducts.Add(OrderProduct.Create(this, product, quantity));
        }

        public void DeleteProduct(Guid orderProductId)
        {
            var toDelete = _orderProducts.Single(x => x.OrderProductId == orderProductId);
            _orderProducts.Remove(toDelete);
        }

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void UpdateProduct(Guid orderProductId, bool purchased)
        {
            _orderProducts.Single(x => x.OrderProductId == orderProductId).UpdatePurchased(purchased);
        }
    }
}
