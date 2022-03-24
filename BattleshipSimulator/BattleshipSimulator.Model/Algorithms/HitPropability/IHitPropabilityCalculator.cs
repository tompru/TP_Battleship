using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Algorithms.HitPropability;

public interface IHitPropabilityCalculator
{
    IReadOnlyList<CoordinatesHitPropability> Calculate(
        BoardShips enemyShips,
        TrackingBoardSquares boardSquares);
}