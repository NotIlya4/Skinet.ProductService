using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.EntityFramework.Models;

public class DataMapper
{
    public Product MapProduct(ProductData productData)
    {
        return new Product(
            id: new Guid(productData.Id),
            name: new Name(productData.Name),
            description: new Description(productData.Description),
            price: new Price(productData.Price),
            pictureUrl: new Uri(productData.PictureUrl),
            productType: new ProductType(productData.ProductType.Name),
            brand: new Brand(productData.Brand.Name));
    }

    public List<Product> MapProduct(IEnumerable<ProductData> productDatas)
    {
        return productDatas.Select(MapProduct).ToList();
    }

    public ProductData MapProduct(Product product, ProductTypeData productTypeData, BrandData brandData)
    {
        return new ProductData(
            id: product.Id.ToString(),
            name: product.Name.Value,
            description: product.Description.Value,
            price: product.Price.Value,
            pictureUrl: product.PictureUrl.ToString(),
            productType: productTypeData,
            brand: brandData);
    }

    public Brand MapBrand(BrandData brandData)
    {
        return new Brand(brandData.Name);
    }

    public List<Brand> MapBrand(IEnumerable<BrandData> brandDatas)
    {
        return brandDatas.Select(MapBrand).ToList();
    }

    public BrandData MapBrand(int id, Brand brand)
    {
        return new BrandData(
            id: id,
            name: brand.Value);
    }

    public ProductType MapProductType(ProductTypeData productTypeData)
    {
        return new ProductType(productTypeData.Name);
    }

    public List<ProductType> MapProductType(IEnumerable<ProductTypeData> productTypeDatas)
    {
        return productTypeDatas.Select(MapProductType).ToList();
    }

    public ProductTypeData MapProductType(int id, ProductType productType)
    {
        return new ProductTypeData(
            id: id,
            name: productType.Value);
    }
}