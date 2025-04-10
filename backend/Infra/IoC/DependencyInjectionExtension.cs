using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infra.IoC;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CoincideContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CoincideContext")!);
        });

        return serviceCollection;
    }
}
