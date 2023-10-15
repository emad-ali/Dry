namespace EmadAli.Dry;

public interface IProcess<T>
{
    Task<T> ExecuteAsync(T input);
}
