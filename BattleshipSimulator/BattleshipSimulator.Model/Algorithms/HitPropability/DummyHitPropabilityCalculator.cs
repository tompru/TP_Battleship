using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Algorithms.HitPropability;

public class DummyHitPropabilityCalculator : IHitPropabilityCalculator
{
    public IReadOnlyList<CoordinatesHitPropability> Calculate(
        BoardShips enemyShips,
        TrackingBoardSquares boardSquares)
    {
        var notMarkedSquares = boardSquares.Values.Where(x => x.IsMarked is false).ToList();
        var notSunkEnemyShips = enemyShips.Values.Where(x => x.IsSunk is false).ToList();

        if (notMarkedSquares.Count == 0)
        {
            return boardSquares.Values
                .Select(x => new CoordinatesHitPropability(x.Coordinates, HitPropability.Zero()))
                .ToList();
        }

        var hitPropability = HitPropability.From(
            (decimal)notSunkEnemyShips.Sum(x => x.Size.Value - x.DamageTaken.Value) / notMarkedSquares.Count);

        var result = new List<CoordinatesHitPropability>();

        foreach (var square in boardSquares.Values)
        {
            var squareHitPropability = square.IsMarked ? HitPropability.Zero() : hitPropability;
            result.Add(new CoordinatesHitPropability(square.Coordinates, squareHitPropability));
        }

        return result;
    }
}