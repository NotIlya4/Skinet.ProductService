using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Extensions;

public static class ServiceCollectionExtensions
{
    public static ServiceDescriptor GetServiceByType(this IServiceCollection services, Type type)
    {
        return services.Single(s => s.ServiceType == type);
    }

    public static void RemoveServiceByType(this IServiceCollection services, Type type)
    {
        var dbOptionsDescriptor = services.GetServiceByType(typeof(DbContextOptions<AppDbContext>));
        services.Remove(dbOptionsDescriptor);
    }
}