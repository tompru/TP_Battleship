using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Results;

namespace BattleshipSimulator.Model.Engine;

public class Game
{
    private readonly IShipArranger _arranger;

    public Game(IShipArranger arranger)
    {
        _arranger = arranger;
    }

    public Player? PlayerA { get; private set; }
    public Player? PlayerB { get; private set; }

    public OperationResult SetupNewGame()
    {
        PlayerA = new Player(_arranger);
        PlayerB = new Player(_arranger);
        var firstPlayerSetupResult = PlayerA.SetupEnemyShips(PlayerB.PrimaryBoard.Ships);
        if (firstPlayerSetupResult.Failure)
        {
            return firstPlayerSetupResult;
        }
        var secondPlayerSetupResult = PlayerB.SetupEnemyShips(PlayerA.PrimaryBoard.Ships);
        if (secondPlayerSetupResult.Failure)
        {
            return secondPlayerSetupResult;
        }
        return new SuccessResult();
    }
}