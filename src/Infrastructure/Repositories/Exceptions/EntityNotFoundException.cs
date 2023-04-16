namespace Infrastructure.Repositories.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName) : base($"Specified {entityName} wasn't found")
    {
        
    }
}