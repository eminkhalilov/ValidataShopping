using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Queries;
using ValidataShopping.Application.SeedWork;

namespace ValidataShopping.Application.Customers.GetCustomerOrders
{
    public class GetCustomerOrdersHandler : IQueryHandler<GetCustomerOrdersQuery, IEnumerable<CustomerOrdersDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetCustomerOrdersHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<CustomerOrdersDto>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            IDbConnection dbConnection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT " +
                "OrderId, " +
                "Title, " +
                "OrderDate " +
                "FROM " +
                "Orders " +
                "WHERE CustomerId = @CustomerId ORDER BY OrderDate DESC";

            IEnumerable<CustomerOrdersDto> orders = await dbConnection.QueryAsync<CustomerOrdersDto>(sql, new { request.CustomerId });

            return orders.ToList();
        }
    }
}
