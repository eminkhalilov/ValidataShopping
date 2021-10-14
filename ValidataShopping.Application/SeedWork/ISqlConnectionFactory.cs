using System.Data;

namespace ValidataShopping.Application.SeedWork
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
