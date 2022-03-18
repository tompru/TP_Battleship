namespace BattleshipSimulator.Model.Results;

public class ErrorResult : OperationResult
{
    public ErrorResult(string message = "") : base(message)
    {
        Success = false;
    }
} 