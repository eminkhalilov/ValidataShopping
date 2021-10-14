using ValidataShopping.Domain.SeedWork;
using ValidataShopping.Infrastructure.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Infrastructure.SqlServer.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ValidataShoppingContext _validataShoppingContext;

        public UnitOfWork(ValidataShoppingContext validataShoppingContext)
        {
            _validataShoppingContext = validataShoppingContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _validataShoppingContext.SaveChangesAsync(cancellationToken);
        }
    }
}
