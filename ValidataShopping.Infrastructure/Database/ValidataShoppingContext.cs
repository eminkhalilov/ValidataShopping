using Microsoft.EntityFrameworkCore;
using ValidataShopping.Domain.Customers;
using ValidataShopping.Domain.Orders;
using ValidataShopping.Domain.Products;

namespace ValidataShopping.Infrastructure.SqlServer.Database
{
    public class ValidataShoppingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ValidataShoppingContext(DbContextOptions<ValidataShoppingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValidataShoppingContext).Assembly);
        }
    }
}
