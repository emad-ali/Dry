
namespace EmadAli.Dry;

public abstract class Pipeline<T>
{
    private readonly List<IProcess<T>> processes = new List<IProcess<T>>();

    /// <summary>
    /// Add a filter "process | operation" to the pipeline 
    /// </summary>
    /// <param name="process">Filter "Process | Operation"</param>
    public Pipeline<T> Add(IProcess<T> process)
    {
        processes.Add(process);
        return this;
    }

    /// <summary>
    /// Process the message through the pipeline to get the result
    /// </summary>
    /// <param name="message">Message to be processed</param>
    /// <returns>T</returns>
    public T Process(T message)
    {
        return processes.Aggregate(message, (msgUnderProcessing, process) => process.Execute(msgUnderProcessing));
    }
    /// <summary>
    /// Build the pipeline by adding IProcess/es
    /// </summary>
    /// <returns>Pipeline</returns>
    public abstract Pipeline<T> Build();

}
