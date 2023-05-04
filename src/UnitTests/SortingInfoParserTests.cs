using Api.Controllers.ProductsControllers.Helpers;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;

namespace UnitTests;

public class SortingInfoParserTests
{
    private readonly SortingInfoParser _parser;
    
    public SortingInfoParserTests()
    {
        _parser = new SortingInfoParser();
    }

    [Fact]
    public void ParseProductSortingInfo_PassValidSorting_ParsedSortingInfo()
    {
        var rawSortingInfo = new List<string>()
        {
            "+name",
            "-name",
            "+price",
            "-price"
        };
        var expect = new List<ProductSorting>()
        {
            new ProductSorting(ProductSortingProperty.Name, SortingSide.Asc),
            new ProductSorting(ProductSortingProperty.Name, SortingSide.Desc),
            new ProductSorting(ProductSortingProperty.Price, SortingSide.Asc),
            new ProductSorting(ProductSortingProperty.Price, SortingSide.Desc)
        };

        List<ProductSorting> result = _parser.ParseProductSortingInfo(rawSortingInfo);
        
        Assert.Equal(expect, result);
    }
}