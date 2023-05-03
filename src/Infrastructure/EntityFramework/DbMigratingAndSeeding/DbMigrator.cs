using Infrastructure.Misc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.DbMigratingAndSeeding;

public class DbMigrator
{
    private readonly IServiceProvider _services;

    public DbMigrator(IServiceProvider services)
    {
        _services = services;
    }
    
    public async Task Migrate()
    {
        await _services.UsingScope<AppDbContext>(async dbContext => { await dbContext.Database.MigrateAsync(); });
    }
}