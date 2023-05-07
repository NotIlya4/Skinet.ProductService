namespace Infrastructure.Repositories.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : this("Entity")
    {
        
    }
    
    public EntityNotFoundException(string entityName) : base($"Specified {entityName} wasn't found")
    {
        
    }

    public EntityNotFoundException(string entityName, Exception innerException) : base($"Specified {entityName} wasn't found", innerException)
    {
        
    }
}