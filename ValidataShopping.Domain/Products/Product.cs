using ValidataShopping.Domain.SeedWork;
using System;

namespace ValidataShopping.Domain.Products
{
    public class Product : IAggregateRoot
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }

        private Product()
        {                
        }

        public static Product Create(string name)
        {
            return new Product() { Name = name };
        }
    }
}
