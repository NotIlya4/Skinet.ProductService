using Api.Controllers.ProductsControllers.Helpers;
using Api.ExceptionCatching;
using Domain.Exceptions;
using ExceptionCatcherMiddleware.Extensions;
using ExceptionCatcherMiddleware.Options;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.ProductService;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using SwaggerEnrichers.Extensions;

namespace Api.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<SortingInfoParser>();
    }
    
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IBrandRepository, BrandRepository>();
        serviceCollection.AddScoped<IProductTypeRepository, ProductTypeRepository>();
    }

    public static void AddAppDbContext(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }

    public static void AddConfiguredExceptionCatcherMiddlewareServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddExceptionCatcherMiddlewareServices(optionsBuilder =>
        {
            optionsBuilder.CompilePolicy = MapperMethodsCompilePolicy.CompileAllAtStart;
            
            optionsBuilder.RegisterExceptionMapper<EntityNotFoundException, EntityNotFoundExceptionMapper>();
            optionsBuilder.RegisterExceptionMapper<DomainValidationException, ValidationExceptionMapper>();
        });
    }

    public static void AddMappers(this IServiceCollection services)
    {
        services.AddScoped<DataMapper>();
        services.AddScoped<ViewMapper>();
    }

    public static void AddConfiguredSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.DescribeAllParametersInCamelCase();
            options.AddEnricherFilters();
            options.EnableAnnotations();
        });
    }

    public static void AddSerilog(this WebApplicationBuilder builder, string seqUrl)
    {
        builder.Services.AddHttpContextAccessor();
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .Enrich.WithCorrelationIdHeader("x-request-id")
            .WriteTo.Console()
            .WriteTo.Seq(seqUrl)
            .Enrich.WithProperty("ServiceName", "ProductService")
            .CreateLogger();
        builder.Host.UseSerilog();
    }
}