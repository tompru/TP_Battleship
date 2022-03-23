using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Results;

namespace BattleshipSimulator.Model.Engine;

public class Game
{
    public Player? PlayerA { get; private set; }
    public Player? PlayerB { get; private set; }

    public OperationResult SetupNewGame(IShipArranger arranger)
    {
        PlayerA = new Player(arranger);
        PlayerB = new Player(arranger);
        var firstPlayerSetupResult = PlayerA.TrackingBoard.SetupEnemyShips(PlayerB.PrimaryBoard.Ships);
        if (firstPlayerSetupResult.Failure)
        {
            return firstPlayerSetupResult;
        }
        var secondPlayerSetupResult = PlayerB.TrackingBoard.SetupEnemyShips(PlayerA.PrimaryBoard.Ships);
        if (secondPlayerSetupResult.Failure)
        {
            return secondPlayerSetupResult;
        }
        return new SuccessResult();
    }

    public OperationResult PlayRound()
    {
        if (PlayerA is null || PlayerB is null)
        {
            return new ErrorResult("Game is not setup yet.");
        }

        var firstPlayerResult = PlayerA.PlayRound(PlayerB.PrimaryBoard);
        if (firstPlayerResult.Failure)
        {
            return firstPlayerResult;
        }

        if (PlayerB.HasLost)
        {
            return new SuccessResult();
        }

        var secondPlayerResult = PlayerB.PlayRound(PlayerA.PrimaryBoard);
        if (secondPlayerResult.Failure)
        {
            return secondPlayerResult;
        }

        return new SuccessResult();
    }
}