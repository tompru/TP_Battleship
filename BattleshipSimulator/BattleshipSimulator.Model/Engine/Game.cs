using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Results;

namespace BattleshipSimulator.Model.Engine;

public class Game
{
    public Player? PlayerA { get; private set; }
    public Player? PlayerB { get; private set; }

    public OperationResult SetupNewGame(IShipArranger arranger, IHitPropabilityCalculator shootPicker)
    {
        PlayerA = new Player(arranger, shootPicker);
        PlayerB = new Player(arranger, shootPicker);
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

        if (PlayerA.HasLost || PlayerB.HasLost)
        {
            return new ErrorResult("One of players already won the game.");
        }

        var firstPlayerResult = PlayerA.PlayRound(PlayerB.PrimaryBoard);
        if (firstPlayerResult.Failure)
        {
            return firstPlayerResult;
        }

        var secondPlayerResult = PlayerB.PlayRound(PlayerA.PrimaryBoard);
        if (secondPlayerResult.Failure)
        {
            return secondPlayerResult;
        }

        return new SuccessResult();
    }
}