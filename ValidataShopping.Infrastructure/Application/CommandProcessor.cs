using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidataShopping.Application.SeedWork;
using ValidataShopping.Domain.SeedWork;
using ValidataShopping.Infrastructure.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidataShopping.Infrastructure.SqlServer.Application
{
    public class CommandProcessor<TRequest, TResponse> : ICommandProcessor<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ValidataShoppingContext _validataShoppingContext;

        public CommandProcessor(IUnitOfWork unitOfWork, ValidataShoppingContext validataShoppingContext)
        {
            _unitOfWork = unitOfWork;
            _validataShoppingContext = validataShoppingContext;
        }

        public async Task<TResponse> ProcessCommand(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var strategy = _validataShoppingContext.Database.CreateExecutionStrategy();
            TResponse response = await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _validataShoppingContext.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    response = await next();
                    await _unitOfWork.CommitAsync();
                    await transaction.CommitAsync();
                    return response;
                }
            }
            );

            return response;
        }
    }
}
