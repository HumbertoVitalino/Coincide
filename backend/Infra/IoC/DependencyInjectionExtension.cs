using Core.Interfaces;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfra(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddRepositories(configuration);

        return serviceCollection;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CoincideContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CoincideContext")!);
        });

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
        serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();

        return serviceCollection;
    }
}
