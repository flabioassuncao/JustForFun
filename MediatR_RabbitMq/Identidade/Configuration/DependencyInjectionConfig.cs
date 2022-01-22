using MediatR;
using Core.Mediator;
using Identidade.Commands;
using FluentValidation.Results;
using Identidade.Application.Events;

namespace Identidade.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
            services.AddScoped<IRequestHandler<RegisterUserCommand, ValidationResult>, RegisterUserCommandHandler>();

            // Events
            services.AddScoped<INotificationHandler<RegisterUserEvent>, RegisterUserEventHandler>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            //services.AddScoped<IQueries, Queries>();

            // Data
            //services.AddScoped<IRepository, Repository>();
            //services.AddScoped<DbContext>();
        }
    }
}
