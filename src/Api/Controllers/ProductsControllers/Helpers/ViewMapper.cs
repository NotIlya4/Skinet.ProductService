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

    public CreateProductRequest MapCreateProductRequest(CreateProductRequestView view)
    {
        return new CreateProductRequest(name: new Name(view.Name), description: new Description(view.Description),
            price: new Price(view.Price), pictureUrl: view.PictureUrl, productType: new Name(view.ProductType),
            brand: new Name(view.Brand));
    }

    public GetProductsRequest MapGetProductsRequest(GetProductsRequestView view)
    {
        return new GetProductsRequest(
            pagination: MapPagination(view.Offset, view.Limit),
            sorting: new ProductSortingCollection(_sortingInfoParser.ParseProductSortingInfo(view.Sortings)),
            filters: MapProductFluentFilters(productType: view.ProductType, brand: view.Brand, searching: view.Searching));
    }

    private Pagination MapPagination(int? offset, int? limit)
    {
        return offset is not null && limit is not null ? new Pagination(offset.Value, limit.Value) : new Pagination();
    }

    private ProductFluentFilters MapProductFluentFilters(string? productType, string? brand, string? searching)
    {
        Name? ToName(string? value)
        {
            return value is not null ? new Name(value) : null;
        }

        return new ProductFluentFilters(
            productType: ToName(productType),
            brand: ToName(brand),
            searching: ToName(searching));
    }

    public GetProductsResultView MapGetProductsResult(GetProductsResult getProductsResult)
    {
        return new GetProductsResultView(
            products: MapProduct(getProductsResult.Products),
            total: getProductsResult.Total);
    }
}