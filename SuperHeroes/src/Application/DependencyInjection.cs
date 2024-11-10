using Application.Abstractions.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);//Registra tudo que for ICommand, IQuery, ICommandHandler e IQueryHandler
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));//Registrar ValidationPipelineBehavior
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true); //Registra tudo que é IValidator

        return services;
    }
}
