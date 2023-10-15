namespace EmadAli.Dry;

public abstract class Entity
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    private readonly List<IDomainEvent> events = new();
    public IReadOnlyCollection<IDomainEvent> Events => events.AsReadOnly();
    public void AddEvent(IDomainEvent @event)
    {
        events.Add(@event);
    }
    public void ClearEvents()
    {
        events.Clear();
    }
    public override bool Equals(object? other)
    {
        if (other == null || GetType() != other.GetType())
            return false;
        Entity? entity = other as Entity;
        if (entity == null) return false;
        return Id.Equals(entity.Id);

    }

    public static bool operator ==(Entity? fst, Entity? snd)
    {
        if (fst is null && snd is null) return true;
        if (fst is null || snd is null) return false;
        return fst.Equals(snd);
    }
    public static bool operator !=(Entity? fst, Entity? snd)
    {
        return !(fst == snd);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}