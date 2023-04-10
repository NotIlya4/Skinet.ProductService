# Skinet.ProductService
This is a REST API Service that provides information about products. In the future, I plan to add RabbitMQ messages to the service.

## Environment
The service has several environment files, including `appsettings.json`, `appsettings.DockerCompose.json`, and `appsettings.IntegrationTests.json`. These files are used to provide different connection strings based on the environment.

When the environment name is not `DockerCompose` or `IntegrationTests`, the service uses `appsettings.json` and localhost as the default connection string. When the environment is `DockerCompose`, the service uses `sql-server`. When the environment is `IntegrationTests`, the service uses `localhost` and a `ProductServiceIntegrationTests` db.

Additionally, the service has two environment variables: `AutoMigrate` and `AutoSeed`. These variables control whether the service should apply migrations or seed the database with sample data at startup.

## Migrations

To apply migrations, set `AutoMigrate=true` in the Docker Compose environment. You can also apply migrations manually by running the EF migrations bundle, which is located in the `app/` container's directory. To do this, run the command 
```
docker exec -it product-service /app/migrations-bundle
```
or run the Python script.