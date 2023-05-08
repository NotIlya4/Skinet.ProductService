# ProductService
This is a REST API Service that provides CRUD endpoints for managing products, brands, and product types.

## Environment Variables
Service contains two environment variables that you can change to control its behavior:
- `AutoMigrate`: When set to `true`, the service will automatically apply any necessary database migrations on startup. When set to `false`, you must apply the migrations manually.
- `AutoSeed`: When set to `true`, the service will automatically seed the database with sample data on startup.

By default, both of these variables are set to `true`.

## Database Migrations
You can apply migrations manually. Container contains entity framework migrations bundle at `/app/efbundle`. You can either run script `ApplyMigrations.py` or command yourself:
```
docker exec -it product-service /app/efbundle
```