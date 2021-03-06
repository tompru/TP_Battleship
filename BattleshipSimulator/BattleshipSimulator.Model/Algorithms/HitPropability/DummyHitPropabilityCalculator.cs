using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Algorithms.HitPropability;

public class DummyHitPropabilityCalculator : IHitPropabilityCalculator
{
    public IReadOnlyList<CoordinatesHitPropability> Calculate(
        BoardShips? enemyShips,
        TrackingBoardSquares boardSquares)
    {
        var notMarkedSquares = boardSquares.Values.Where(x => x.IsMarked is false).ToList();

        if (enemyShips is null || notMarkedSquares.Count == 0)
        {
            return boardSquares.Values
                .Select(x => new CoordinatesHitPropability(x.Coordinates, HitPropability.Zero))
                .ToList();
        }

        var notSunkEnemyShips = enemyShips.Values.Where(x => x.IsSunk is false).ToList();

        var hitPropability = CalculateSquaresHitPropability(notSunkEnemyShips, notMarkedSquares.Count);

        var result = new List<CoordinatesHitPropability>();

        foreach (var square in boardSquares.Values)
        {
            var squareHitPropability = square.IsMarked ? HitPropability.Zero : hitPropability;
            result.Add(new CoordinatesHitPropability(square.Coordinates, squareHitPropability));
        }

        return result;
    }

    private static HitPropability CalculateSquaresHitPropability(
        IEnumerable<Ship> notSunkEnemyShips,
        int notMarkedSquaresCount)
    {
        var hitPropability = notSunkEnemyShips.Sum(x => x.Size - x.DamageTaken) / (decimal)notMarkedSquaresCount;

        return HitPropability.From(hitPropability);
    }
}