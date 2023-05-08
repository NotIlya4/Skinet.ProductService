using Domain.Entities;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;

namespace UnitTests.Infrastructure.SortingSystem;

public class ProductSortingCollectionConstructorTests
{
    [Fact]
    public void EmptyList_PrimarySortingDefaultValue()
    {
        ProductSorting defaultSorting = new(ProductSortingProperty.Name, SortingSide.Asc);
        ProductSortingCollection productSortingCollection = new(new List<ProductSorting>());

        Sorting sorting = productSortingCollection.PrimarySorting;
        
        Assert.Equal(defaultSorting.Sorting, sorting);
    }

    [Fact]
    public void ThreeSortingInfos_PrimarySortingInfoMustBeFirstAndRestIsSecondSortingInfos()
    {
        ProductSorting first = new(nameof(Product.Name), SortingSide.Asc);
        ProductSorting second = new(nameof(Product.Name), SortingSide.Desc);
        ProductSorting third = new(nameof(Product.Name), SortingSide.Desc);
        ProductSortingCollection productSortingCollection = new(new List<ProductSorting>() {first, second, third});
        
        Assert.Equal(first.Sorting, productSortingCollection.PrimarySorting);
        Assert.Equal(second.Sorting, productSortingCollection.SecondarySortings[0]);
        Assert.Equal(third.Sorting, productSortingCollection.SecondarySortings[1]);
    }
}