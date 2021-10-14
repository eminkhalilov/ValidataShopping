using Microsoft.EntityFrameworkCore;
using ValidataShopping.Domain.Products;
using ValidataShopping.Infrastructure.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ValidataShopping.Infrastructure.SqlServer.Domain.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ValidataShoppingContext _validataShoppingContext;

        public ProductRepository(ValidataShoppingContext validataShoppingContext)
        {
            _validataShoppingContext = validataShoppingContext;
        }

        public async Task AddRangeAsync(List<ValidataShopping.Domain.Products.Product> newProducts)
        {
            await _validataShoppingContext.Products.AddRangeAsync(newProducts);
        }

        public async Task<bool> AnyAsync()
        {
            return await _validataShoppingContext.Products.AnyAsync();
        }

        public async Task<ValidataShopping.Domain.Products.Product> GetProduct(Guid productId)
        {
            var product = await _validataShoppingContext.Products.SingleOrDefaultAsync(x => x.ProductId == productId);
            return product;
        }
    }
}
