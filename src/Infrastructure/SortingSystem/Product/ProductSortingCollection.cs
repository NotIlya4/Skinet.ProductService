namespace Infrastructure.SortingSystem.Product;

public record ProductSortingCollection
{
    public Sorting PrimarySorting { get; }
    public List<Sorting> SecondarySortings { get; }

    public ProductSortingCollection() : this(new List<ProductSorting>())
    {
        
    }
    
    public ProductSortingCollection(ProductSorting sorting) 
        : this(new List<ProductSorting>() {sorting})
    {
        
    }
    
    public ProductSortingCollection(List<ProductSorting> sortingInfos)
    {
        PrimarySorting = sortingInfos.Count == 0
            ? new ProductSorting(ProductSortingProperty.Name, SortingSide.Asc).Sorting
            : sortingInfos[0].Sorting;
        SecondarySortings = sortingInfos.Skip(1).Select(p => p.Sorting).ToList();
    }
}