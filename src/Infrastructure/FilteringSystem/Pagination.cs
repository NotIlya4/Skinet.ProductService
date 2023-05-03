namespace Infrastructure.FilteringSystem;

public record Pagination
{
    public int Offset { get; }
    public int Limit { get; }

    public static int MaxLimit => 50;

    public Pagination() : this(0, MaxLimit)
    {
        
    }
    
    public Pagination(int offset, int limit)
    {
        if (offset < 0)
        {
            throw new InvalidOperationException($"offset must be grater than 0, actual value {offset}");
        }
        
        if (limit < 1 || limit > MaxLimit)
        {
            throw new InvalidOperationException($"limit must be grater than 0 and less {MaxLimit}, actual value {limit}");
        }

        Offset = offset;
        Limit = limit;
    }
}