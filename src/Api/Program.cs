using Api.Extensions;
using Api.Properties;
using ExceptionCatcherMiddleware.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ParametersProvider parametersProvider = new(builder.Configuration);

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

app.UseExceptionCatcherMiddleware();
app.UseConfiguredCors();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();