using MediatR;
using ValidataShopping.Application.Configuration.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Application.Products.CreateProduct
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand>
    {
        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
