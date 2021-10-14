using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Queries;
using ValidataShopping.Application.Customers.GetCustomer;
using ValidataShopping.Domain.Customers;

namespace ValidataShopping.Application.Customers.GetAllCustomers
{
    public class GetAllCustomersHandler : IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetAllAsync();
            var customerList = new List<CustomerDto>();
            foreach (var item in customer)
            {
                customerList.Add(new CustomerDto
                {
                    CustomerId = item.CustomerId,
                    Name = item.Name,
                    Address = item.Address,
                    PostalCode = item.PostalCode
                });
            }
            return customerList;

        }
    }
}
