using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException(string msg) : base(msg)
    {
        
    }

    public static void EnsureNotEmpty([NotNull] string? value, string className)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValidationException($"{className} cannot be empty");
        }
    }
}