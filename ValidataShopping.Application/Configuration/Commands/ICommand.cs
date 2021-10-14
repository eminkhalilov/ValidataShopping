using MediatR;

namespace ValidataShopping.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}
