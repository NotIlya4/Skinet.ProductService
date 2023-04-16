namespace Domain.Interfaces;

public interface IEntityComparable<in TEntity>
{
    public bool EqualId(TEntity entity);
}