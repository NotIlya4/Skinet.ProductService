namespace Infrastructure.EntityFramework.Models;

public interface IIdEquitable<in TEntity>
{
    public bool EqualId(TEntity entity);
}