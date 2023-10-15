namespace EmadAli.Dry;

public sealed class Result<T>
{
    private enum ResultState
    {
        Success,
        Fail
    }
    public Result(T value)
    {
        Value = value;
        _state = ResultState.Success;
    }
    public Result(Exception exception)
    {
        Exception = exception;
        _state = ResultState.Fail;
        Value = default;
    }


    private readonly ResultState _state;
    public T? Value { get; private set; }
    public Exception? Exception { get; private set; } = null;
    public bool IsSuccess => _state == ResultState.Success;
    public bool IsFail => !IsSuccess;


    public TR Match<TR>(Func<T, TR> success, Func<Exception, TR> fail) =>
        !IsSuccess ? fail(Exception!) : success(Value!);

    public void OnSuccess(Action<T> action)
    {
        if (IsSuccess) action(Value!);
    }
    public void OnFailure(Action<Exception> action)
    {
        if (IsSuccess) action(Exception!);
    }

    public static implicit operator Result<T>(T value) =>
        new Result<T>(value);

}