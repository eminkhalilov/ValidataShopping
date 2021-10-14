using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Application.SeedWork
{
    public interface ICommandProcessor<TRequest, TResponse>
    {
        Task<TResponse> ProcessCommand(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}
