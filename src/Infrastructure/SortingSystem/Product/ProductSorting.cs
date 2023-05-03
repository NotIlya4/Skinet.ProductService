using Infrastructure.Misc;

namespace Infrastructure.SortingSystem.Product;

public record ProductSorting
{
    public ProductSortingProperty PropertyName { get; }
    public SortingSide SortingSide { get; }
    public Sorting Sorting { get; }

    public ProductSorting(string propertyName, SortingSide sortingSide)
        : this(EnumParser.Parse<ProductSortingProperty>(propertyName), sortingSide)
    {
        
    }

    public ProductSorting(ProductSortingProperty property, SortingSide sortingSide)
    {
        PropertyName = property;
        SortingSide = sortingSide;
        Sorting = new Sorting(property.ToString(), sortingSide);
    }
}