
namespace EmadAli.Dry;

public abstract class BasePipeline<T> : IPipeline<T>
{
    public BasePipeline()
    {
        Build();
    }
    private readonly List<IProcess<T>> processes = new List<IProcess<T>>();

    /// <summary>
    /// Add a filter "process | operation" to the pipeline 
    /// </summary>
    /// <param name="process">Filter "Process | Operation"</param>
    public IPipeline<T> Add(IProcess<T> process)
    {
        processes.Add(process);
        return this;
    }

    /// <summary>
    /// Process the message through the pipeline to get the result
    /// </summary>
    /// <param name="message">Message to be processed</param>
    /// <returns>T</returns>
    public async Task<T> ProcessAsync(T message)
    {
        var res = message;
        foreach (var process in processes)
        {
            res = await process.ExecuteAsync(res);
        }
        return res;
    }
    /// <summary>
    /// Build the pipeline by adding IProcess/es
    /// </summary>
    /// <returns>Pipeline</returns>
    public abstract void Build();

}
