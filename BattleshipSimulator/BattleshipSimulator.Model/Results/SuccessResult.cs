namespace BattleshipSimulator.Model.Results;

public class SuccessResult : OperationResult
{
    public SuccessResult(string message = "") : base(message)
    {
        Success = true;
    }
}