using Api.Properties;
using Infrastructure.EntityFramework.DbMigratingAndSeeding;
using Infrastructure.EntityFramework.DbMigratingAndSeeding.DataLists;

namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static async Task ConfigureDb(this WebApplication applicationBuilder, ParametersProvider parameters)
    {
        if (parameters.AutoMigrate)
        {
            DbMigrator migrator = new(applicationBuilder.Services);
            await migrator.Migrate();
        }

        if (parameters.AutoSeed)
        {
            DbSeeder seeder = new(applicationBuilder.Services, new BrandsToSeed().BrandDatas,
                new ProductTypesToSeed().ProductTypeDatas, new ProductsToSeed().ProductDatas);
            await seeder.Seed();
        }
    }
}