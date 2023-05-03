using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.DbMigratingAndSeeding;
using Infrastructure.Misc;
using IntegrationTests.EntityLists;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

[CollectionDefinition(nameof(AppFixture))]
public class AppFixture : ICollectionFixture<AppFixture>, IAsyncLifetime
{
    public HttpClient Client { get; private set; } = null!;
    internal WebApplicationFactory<Program> WebApplicationFactory { get; private set; } = null!;
    public BrandsList BrandsList { get; private set; } = null!;
    public ProductTypesList ProductTypesList { get; private set; } = null!;
    public ProductsList ProductsList { get; private set; } = null!;
    private DbSeeder _seeder = null!;
    private DbMigrator _migrator = null!;

    public async Task InitializeAsync()
    {
        CreateClient();
        CreateLists();
        CreateMigratorAndSeeder();

        await ReloadDb();
    }

    public async Task DisposeAsync()
    {
        await DeleteDb();
    }

    public async Task ReloadDb()
    {
        await DeleteDb();
        
        await _migrator.Migrate();
        await _seeder.Seed();
    }

    private void CreateLists()
    {
        BrandsList = new BrandsList();
        ProductTypesList = new ProductTypesList();
        ProductsList = new ProductsList(BrandsList, ProductTypesList);
    }

    private void CreateClient()
    {
        WebApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("IntegrationTests");
        });
        
        Client = WebApplicationFactory.CreateClient();
    }

    private void CreateMigratorAndSeeder()
    {
        _migrator = new DbMigrator(WebApplicationFactory.Services);
        _seeder = new DbSeeder(WebApplicationFactory.Services, BrandsList.BrandDatas, ProductTypesList.ProductTypeDatas,
            ProductsList.ProductDatas);
    }

    private async Task DeleteDb()
    {
        await WebApplicationFactory.Services.UsingScope<AppDbContext>(async dbContext =>
        {
            await dbContext.Database.EnsureDeletedAsync();
        });
    }
}