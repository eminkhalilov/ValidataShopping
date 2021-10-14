using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Queries;
using ValidataShopping.Domain.Customers;

namespace ValidataShopping.Application.Customers.GetCustomer
{
    public class GetCustomerHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var customer = await _customerRepository.GetCustomer(request.CustomerId);
            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                PostalCode = customer.PostalCode
            };
        }
    }
}
