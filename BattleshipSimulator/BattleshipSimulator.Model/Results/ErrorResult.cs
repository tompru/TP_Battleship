namespace BattleshipSimulator.Model.Results;

public class ErrorResult : OperationResult
{
    public ErrorResult(string message = "") : base(message)
    {
        Success = false;
    }
}

public class ErrorResult<T> : OperationResult<T>
{
    public ErrorResult(string message = "") : base(default, message)
    {
        Success = false;
    }
}