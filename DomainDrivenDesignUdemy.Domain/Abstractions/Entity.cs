namespace DomainDrivenDesignUdemy.Domain.Abstractions;
public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }

    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj) 
        => obj is Entity entity && Equals(entity);

    public override int GetHashCode() 
        => Id.GetHashCode();

    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Id == Id;
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}
