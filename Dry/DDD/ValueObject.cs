namespace EmadAli.Dry;
public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetComparisonElements();
    public override bool Equals(object? obj)
    {
        if (obj is not ValueObject ob || GetType() != ob.GetType()) return false;
        return GetComparisonElements().SequenceEqual(ob.GetComparisonElements());
    }

    public static bool operator ==(ValueObject fst, ValueObject snd)
    {
        if (fst is null && snd is null) return true;
        if (fst is null || snd is null) return false;
        return fst.Equals(snd);
    }
    public static bool operator !=(ValueObject fst, ValueObject snd)
    {
        return !(fst == snd);
    }
    public override int GetHashCode()
    {
        return GetComparisonElements().Aggregate(1, (current, element) =>
        {
            return current ^ element.GetHashCode();
        });
    }
}
