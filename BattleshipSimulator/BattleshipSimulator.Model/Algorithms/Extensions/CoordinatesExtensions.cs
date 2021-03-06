using BattleshipSimulator.Model.Ships.Metadata;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Algorithms.Extensions;

internal static class CoordinatesExtensions
{
    internal static Coordinates GetEndCoordinates(
        this Coordinates start, Direction direction, ShipSize shipSize) =>
        direction switch
        {
            Direction.Left => new Coordinates(
                Ordinate.From(start.Ordinate - (shipSize - 1)), start.Abscissa),
            Direction.Right => new Coordinates(
                Ordinate.From(start.Ordinate.Value + (shipSize - 1)), start.Abscissa),
            Direction.Up => new Coordinates(
                start.Ordinate, Abscissa.From(start.Abscissa + (shipSize - 1))),
            Direction.Down => new Coordinates(
                start.Ordinate, Abscissa.From(start.Abscissa - (shipSize - 1))),
            _ => throw new ArgumentOutOfRangeException()
        };
}