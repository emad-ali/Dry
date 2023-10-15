
namespace EmadAli.Dry;
public interface IPipeline<T>
{
    IPipeline<T> Add(IProcess<T> process);
    void Build();
    Task<T> ProcessAsync(T message);
}