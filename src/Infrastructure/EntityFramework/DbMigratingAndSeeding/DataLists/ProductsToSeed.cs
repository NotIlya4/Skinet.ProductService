using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.DbMigratingAndSeeding.DataLists;

public class ProductsToSeed
{
    public List<ProductData> ProductDatas { get; }
    private BrandsToSeed BrandSeeder { get; } = new();
    private ProductTypesToSeed ProductTypesToSeed { get; } = new();

    public ProductsToSeed()
    {
        ProductData product1 = new ProductData(
            id: "671cb8a2-d9ee-43a6-8704-c9169206da9a",
            name: "Converse Waterproof Rubber Boots",
            description: "Stay dry in style with these waterproof rubber boots from Converse. Featuring a sleek design and superior grip, they are perfect for any rainy day.",
            price: 75m,
            pictureUrl: "http://localhost:5000/static/pictures/shoes-002-500.jpg",
            brand: BrandSeeder.Converse,
            productType: ProductTypesToSeed.Shoes);
        ProductData product2 = new ProductData(
            id: "90757a26-4a01-4864-b02d-422c393b7050",
            name: "Warrior Slim Fit Pants",
            description: "Unleash your inner beast with these savage skinny pants by Fitwear, built to withstand the toughest workouts and toughest lifestyles.",
            price: 59.99m,
            pictureUrl: "http://localhost:5000/static/pictures/pants-003-500.jpg",
            brand: BrandSeeder.Fitwear,
            productType: ProductTypesToSeed.Pants);
        ProductData product3 = new ProductData(
            id: "97697238-e5ef-489f-a866-82b5a8af328f",
            name: "Fitwear Performance Pants",
            description: "These high-performance pants are made with moisture-wicking fabric and a flexible waistband for ultimate comfort during any workout.",
            price: 69.99m,
            pictureUrl: "http://localhost:5000/static/pictures/pants-001-500.jpg",
            brand: BrandSeeder.Fitwear,
            productType: ProductTypesToSeed.Pants);
        ProductData product4 = new ProductData(
            id: "9f6d6cfd-d919-405a-9c5e-c3c7ead59485",
            name: "Skyline Skinny Fit Pants",
            description: "Comfortable and versatile skinny pants with a modern design for any occasion by Flexpants.",
            price: 54.99m,
            pictureUrl: "http://localhost:5000/static/pictures/pants-002-500.jpg",
            brand: BrandSeeder.Flexpants,
            productType: ProductTypesToSeed.Pants);
        ProductData product5 = new ProductData(
            id: "ac8a34a8-ad32-4474-a17b-82c2a2963e4c",
            name: "Chuck 70 High Top",
            description: "Upgrade your shoe collection with these classic and comfortable Chuck 70 High Top sneakers from Converse, designed for the modern man with style.",
            price: 90m,
            pictureUrl: "http://localhost:5000/static/pictures/shoes-001-500.jpg",
            brand: BrandSeeder.Converse,
            productType: ProductTypesToSeed.Shoes);
        ProductData product6 = new ProductData(
            id: "b1a66082-15d2-4f45-9090-da5ee0598d06",
            name: "Softstyle T-Shirt - Sunshine",
            description: "Brighten up your day with the T-Shirt in Sunshine! Made from a lightweight fabric, this shirt is perfect for any sunny occasion.",
            price: 14.99m,
            pictureUrl: "http://localhost:5000/static/pictures/tshirt-002-500.jpg",
            brand: BrandSeeder.Gildan,
            productType: ProductTypesToSeed.Tshirt);
        ProductData product7 = new ProductData(
            id: "beaaa5d4-e03c-43df-8d73-b20c302caa87",
            name: "Apple Watch",
            description: "Apple Watch: sleek, fitness tracking, messaging, calls, app library, customizable watch faces, for on-the-go lifestyles.",
            price: 499.99m,
            pictureUrl: "http://localhost:5000/static/pictures/watches-001-500.jpg",
            brand: BrandSeeder.Apple,
            productType: ProductTypesToSeed.Watches);
        ProductData product8 = new ProductData(
            id: "ead147d9-a64c-4423-8bcc-fcfc78f85604",
            name: "Hanes Blackout T-Shirt",
            description: "Made from soft and durable cotton, this t-shirt provides ultimate comfort and style for everyday wear.",
            price: 12.99m,
            pictureUrl: "http://localhost:5000/static/pictures/tshirt-003-500.jpg",
            brand: BrandSeeder.Hanes,
            productType: ProductTypesToSeed.Tshirt);
        ProductData product9 = new ProductData(
            id: "f7aa92d6-9bde-4525-bce3-959c4b55aa14",
            name: "Gildan Ultra Cotton T-Shirt",
            description: "Stay comfortable all day long in this classic and durable Gildan Ultra Cotton t-shirt, made from pre-shrunk featuring a seamless collar stitching.",
            price: 15.99m,
            pictureUrl: "http://localhost:5000/static/pictures/tshirt-001-500.jpg",
            brand: BrandSeeder.Gildan,
            productType: ProductTypesToSeed.Tshirt);

        ProductDatas = new List<ProductData>()
            { product1, product2, product3, product4, product5, product6, product7, product8, product9 };
    }
}