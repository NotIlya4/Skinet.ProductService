using Api.Extensions;
using Api.Properties;
using ExceptionCatcherMiddleware.Extensions;
using Infrastructure.FilteringSystem.Product;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ParametersProvider parametersProvider = new(builder.Configuration);

builder.AddSerilog(parametersProvider.SeqUrl());
services.AddServices();
services.AddRepositories();
services.AddMappers();
services.AddAppDbContext(parametersProvider.GetSqlServer());
services.AddConfiguredExceptionCatcherMiddlewareServices();
services.AddConfiguredSwaggerGen();
services.AddConfiguredCors();

services.AddControllers();
services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

await app.ConfigureDb(parametersProvider);

app.UseSerilogRequestLogging();
app.UseExceptionCatcherMiddleware();
app.UseConfiguredCors();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();