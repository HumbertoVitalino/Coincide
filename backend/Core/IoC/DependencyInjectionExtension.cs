using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Core.IoC;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
