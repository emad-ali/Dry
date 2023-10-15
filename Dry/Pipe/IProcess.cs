namespace EmadAli.Dry;

public interface IProcess<T>
{
    T Execute(T input);
}
