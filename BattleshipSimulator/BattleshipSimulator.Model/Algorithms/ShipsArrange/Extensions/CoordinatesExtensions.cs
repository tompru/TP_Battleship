using BattleshipSimulator.Model.Board.Axes;
using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Algorithms.ShipsArrange.Extensions;

internal static class CoordinatesExtensions
{
    internal static Coordinates GetEndCoordinates(
        this Coordinates start, Direction direction, ShipSize shipSize) =>
        direction switch
        {
            Direction.Left => new Coordinates(
                Ordinate.From(start.Ordinate.Value - (shipSize.Value - 1)), start.Abscissa),
            Direction.Right => new Coordinates(
                Ordinate.From(start.Ordinate.Value + (shipSize.Value - 1)), start.Abscissa),
            Direction.Up => new Coordinates(
                start.Ordinate, Abscissa.From(start.Abscissa.Value + (shipSize.Value - 1))),
            Direction.Down => new Coordinates(
                start.Ordinate, Abscissa.From(start.Abscissa.Value - (shipSize.Value - 1))),
            _ => throw new ArgumentOutOfRangeException()
        };
}