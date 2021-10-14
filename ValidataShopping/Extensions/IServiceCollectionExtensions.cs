using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ValidataShopping.API.Orders.Validators;
using ValidataShopping.Application.Configuration.Commands;
using ValidataShopping.Application.Configuration.UnitOfWork;
using ValidataShopping.Application.SeedWork;
using ValidataShopping.Infrastructure.SqlServer.Application;

namespace ValidataShopping.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommand));
            services.AddScoped(typeof(ICommandProcessor<,>), typeof(CommandProcessor<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CQRSPipelineBehaviour<,>));
            return services;
        }

        public static IServiceCollection AddControllersServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(x => {
                    x.RegisterValidatorsFromAssemblyContaining<UpdateOrderProductRequestValidator>();
                    x.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });
            return services;
        }
    }
}
