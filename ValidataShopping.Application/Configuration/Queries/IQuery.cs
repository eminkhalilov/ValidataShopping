using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidataShopping.Application.Configuration.Queries
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
