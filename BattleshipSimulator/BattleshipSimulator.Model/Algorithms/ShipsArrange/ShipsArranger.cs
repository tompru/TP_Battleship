using BattleshipSimulator.Model.Algorithms.ShipsArrange.Extensions;
using BattleshipSimulator.Model.Board;
using BattleshipSimulator.Model.Board.Axes;
using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Model.Algorithms.ShipsArrange;

internal static class ShipsArranger
{
    private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

    private static readonly List<Direction> Directions = new()
    {
        Direction.Left,
        Direction.Right,
        Direction.Up,
        Direction.Down
    };

    public static void ArrangeRandomly(BoardShips ships, BoardSquares squares)
    {
        var maxOrdinate = squares.Values.Max(x => x.Coordinates.Ordinate.Value);
        var maxAbscissa = squares.Values.Max(x => x.Coordinates.Abscissa.Value);

        foreach (var ship in ships.Values)
        {
            var placingShipInProgress = true;
            while (placingShipInProgress)
            {
                var startCoordinates = PickRandomCoordinates(maxOrdinate, maxAbscissa);
                foreach (var direction in Directions)
                {
                    var endCoordinates = startCoordinates.GetEndCoordinates(direction, ship.Size);
                    if (endCoordinates.IsValid(maxOrdinate, maxAbscissa) is false)
                    {
                        continue;
                    }

                    var coordinates = Coordinates.GetCoordinatesBetween(startCoordinates, endCoordinates);

                    var placeShipResult = squares.PlaceShip(coordinates, ship.Id);
                    if (placeShipResult.Failure)
                    {
                        continue;
                    }

                    placingShipInProgress = false;
                }
            }
        }
    }

    private static Coordinates PickRandomCoordinates(int maxOrdinate, int maxAbscissa)
    {
        var ordinate = Ordinate.From(Random.Next(Coordinates.MinAxisValue, maxOrdinate + 1));
        var abscissa = Abscissa.From(Random.Next(Coordinates.MinAxisValue, maxAbscissa + 1));
        return new Coordinates(ordinate, abscissa);
    }
}