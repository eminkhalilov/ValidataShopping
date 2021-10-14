using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Customers;

namespace ValidataShopping.Application.Customers.CreateCustomer
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.Name, request.Address, request.PostalCode);
            await _customerRepository.AddAsync(customer);
            return Unit.Value;
        }
    }
}
