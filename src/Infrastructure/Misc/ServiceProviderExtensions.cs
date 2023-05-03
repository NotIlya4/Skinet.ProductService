using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Misc;

public static class ServiceProviderExtensions
{
    public static async Task UsingScope(this IServiceProvider services, Func<IServiceProvider, Task> lambda)
    {
        AsyncServiceScope scope = services.CreateAsyncScope();
        try
        {
            await lambda(scope.ServiceProvider);
        }
        catch (Exception)
        {
            await scope.DisposeAsync();
            throw;
        }
    }
    
    public static async Task UsingScope<TService>(this IServiceProvider services, Func<TService, Task> lambda) where TService : notnull
    {
        await services.UsingScope(async lambdaServices =>
        {
            TService service = lambdaServices.GetRequiredService<TService>();
            await lambda(service);
        });
    }
}