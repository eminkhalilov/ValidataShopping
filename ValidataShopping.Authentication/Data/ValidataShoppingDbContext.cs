using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ValidataShopping.Authentication.Data.Models;

namespace ValidataShopping.Authentication.Data
{
    public class ValidataShoppingDbContext : IdentityDbContext<User>
    {
        public ValidataShoppingDbContext(DbContextOptions<ValidataShoppingDbContext> options)
            : base(options)
        {
        }
    }
}
