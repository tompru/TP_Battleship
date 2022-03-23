namespace BattleshipSimulator.Model.Results;

public class SuccessResult : OperationResult
{
    public SuccessResult(string message = "") : base(message)
    {
        Success = true;
    }
}

public class SuccessResult<T> : OperationResult<T>
{
    public SuccessResult(T? payload, string message = "") : base(payload, message)
    {
        Success = true;
    }
}