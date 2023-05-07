using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException()
    {
        
    }
    
    public DomainValidationException(string msg) : base(msg)
    {
        
    }

    public DomainValidationException(string msg, Exception innerException) : base(msg, innerException)
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