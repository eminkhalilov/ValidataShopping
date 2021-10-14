using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Domain.Customers;

namespace ValidataShopping.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteCustomer(request.CustomerId);
            return Unit.Value;
        }
    }
}
