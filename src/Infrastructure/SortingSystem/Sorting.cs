namespace Infrastructure.SortingSystem;

public record Sorting
{
    public string PropertyName { get; }
    public SortingSide SortingSide { get; }

    public Sorting(string propertyName, SortingSide sortingSide)
    {
        PropertyName = propertyName;
        SortingSide = sortingSide;
    }
}