namespace Api.ExceptionCatching;

public class BadResponseDto
{
    public required string Title { get; init; }
    public required string Detail { get; init; }
}