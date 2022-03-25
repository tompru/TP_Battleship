using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Engine;
using BattleshipSimulator.Model.Results;

namespace BattleshipSimulator.Panel.Data;

public class GameService
{
    private readonly IShipArranger _shipArranger;
    private readonly IHitPropabilityCalculator _propabilityCalculator;

    public GameService(
        IShipArranger shipArranger,
        IHitPropabilityCalculator propabilityCalculator)
    {
        _shipArranger = shipArranger;
        _propabilityCalculator = propabilityCalculator;
    }

    public void SetupNewGame(Game game) => game.SetupNewGame(_shipArranger, _propabilityCalculator);

    public OperationResult NextRound(Game game) => game.PlayRound();
}