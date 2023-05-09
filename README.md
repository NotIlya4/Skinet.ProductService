# ProductService
This is a REST API Service that provides CRUD endpoints for managing products, brands, and product types. See swagger for endpoints docs.

## Environment Variables
Service contains several environment variables that you can change to control its behavior:
- `AutoMigrate` When set to `true`, the service will automatically apply any necessary database migrations on startup. When set to `false`, you must apply the migrations manually.
- `AutoSeed` When set to `true`, the service will automatically seed the database with sample data on startup.

Also there are some variables that are not intended to be changed:
- `SeqUrl` Seq url.
- `Serilog` Serilog logging settings.
- `SqlServer__Server` Sql server url.
- `SqlServer__Database` Sql server database.
- `SqlServer__User Id` Sql server user.
- `SqlServer__Password` Sql server user's password.

## Database Migrations
You can apply migrations manually. Container contains entity framework migrations bundle at `/app/efbundle`. You can either run script `ApplyMigrations.py` or command yourself:
```
docker exec -it product-service /app/efbundle
```