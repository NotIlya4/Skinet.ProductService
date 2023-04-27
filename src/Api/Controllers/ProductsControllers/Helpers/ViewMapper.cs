using Api.Controllers.ProductsControllers.Views;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.SortingSystem.Product;

namespace Api.Controllers.ProductsControllers.Helpers;

public class ViewMapper
{
    private readonly SortingInfoParser _sortingInfoParser;

    public ViewMapper(SortingInfoParser sortingInfoParser)
    {
        _sortingInfoParser = sortingInfoParser;
    }
    
    public Product MapProduct(ProductView productData)
    {
        return new Product(
            id: productData.Id,
            name: new Name(productData.Name),
            description: new Description(productData.Description),
            price: new Price(productData.Price),
            pictureUrl: productData.PictureUrl,
            productType: new Name(productData.ProductType),
            brand: new Name(productData.Brand));
    }

    public List<Product> MapProduct(IEnumerable<ProductView> productViews)
    {
        return productViews.Select(MapProduct).ToList();
    }

    public ProductView MapProduct(Product product)
    {
        return new ProductView(
            id: product.Id,
            name: product.Name.Value,
            description: product.Description.Value,
            price: product.Price.Value,
            pictureUrl: product.PictureUrl,
            productType: product.ProductType.Value,
            brand: product.Brand.Value);
    }
    
    public List<ProductView> MapProduct(IEnumerable<Product> products)
    {
        return products.Select(MapProduct).ToList();
    }

    public CreateProductCommand MapCreateProductCommand(CreateProductCommandView view)
    {
        return new CreateProductCommand(name: new Name(view.Name), description: new Description(view.Description),
            price: new Price(view.Price), pictureUrl: view.PictureUrl, productType: new Name(view.ProductType),
            brand: new Name(view.Brand));
    }

    public GetProductsQuery MapGetProductsQuery(GetProductsQueryView view)
    {
        Name? productTypeName = view.ProductType is not null ? new Name(view.ProductType) : null;
        Name? brandName = view.Brand is not null ? new Name(view.Brand) : null;
        Name? searching = view.Searching is not null ? new Name(view.Searching) : null;
        return new GetProductsQuery(
            pagination: new Pagination(offset: view.Offset, limit: view.Limit),
            sortingCollection: new ProductSortingCollection(_sortingInfoParser.ParseProductSortingInfo(view.Sortings)),
            fluentFilters: new ProductFluentFilters(
                productTypeName: productTypeName,
                brandName: brandName,
                searching: searching));
    }

    public GetProductsResultView MapGetProductsResult(GetProductsResult getProductsResult)
    {
        return new GetProductsResultView(
            products: MapProduct(getProductsResult.Products),
            total: getProductsResult.Total);
    }
}