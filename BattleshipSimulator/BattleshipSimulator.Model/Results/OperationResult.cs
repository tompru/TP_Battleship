namespace BattleshipSimulator.Model.Results;

public abstract class OperationResult
{
    protected OperationResult(string message = "")
    {
        Message = message;
    }

    public bool Success { get; protected set; }
    public bool Failure => Success is false;
    public string Message { get; }
}

public abstract class OperationResult<T> : OperationResult
{
    protected OperationResult(T? payload, string message = "") : base(message)
    {
        Payload = payload;
    }

    public T? Payload { get; }
}