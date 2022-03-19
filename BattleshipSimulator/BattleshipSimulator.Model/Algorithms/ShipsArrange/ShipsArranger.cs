using BattleshipSimulator.Model.Board;
using BattleshipSimulator.Model.Board.Axes;
using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Model.Algorithms.ShipsArrange;

internal static class ShipsArranger
{
    private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

    private static readonly List<(Orientation Orientation, Side Side)> Directions = new()
    {
        (Orientation.Horizontal, Side.Left),
        (Orientation.Horizontal, Side.Right),
        (Orientation.Vertical, Side.Left),
        (Orientation.Vertical, Side.Right)
    };

    public static void ArrangeRandomly(BoardShips ships, BoardSquares squares)
    {
        var maxOrdinate = squares.Values.Max(x => x.Coordinates.Ordinate.Value);
        var maxAbscissa = squares.Values.Max(x => x.Coordinates.Abscissa.Value);

        foreach (var ship in ships.Values)
        {

        }
    }

    private static Ordinate PickStartOrdinate(short maxOrdinate) =>
        Ordinate.From((short)Random.Next(1, maxOrdinate + 1));

    private static Abscissa PickStartAbscissa(short maxAbscissa) =>
        Abscissa.From((short)Random.Next(1, maxAbscissa + 1));
}