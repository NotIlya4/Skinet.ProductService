using Api.Extensions;
using Api.Properties;
using ExceptionCatcherMiddleware.Extensions;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ParametersProvider parametersProvider = new(builder.Configuration);

builder.AddSerilog(parametersProvider.Seq);
services.AddServices();
services.AddRepositories();
services.AddMappers();
services.AddAppDbContext(parametersProvider.SqlServer);
services.AddConfiguredExceptionCatcherMiddlewareServices();
services.AddConfiguredSwaggerGen();

services.AddControllers();
services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

await app.ConfigureDb(parametersProvider);

app.UseSerilogRequestLogging();
app.UseExceptionCatcherMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();