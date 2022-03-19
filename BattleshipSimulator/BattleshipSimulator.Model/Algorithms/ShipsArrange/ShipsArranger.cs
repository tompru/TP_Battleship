using BattleshipSimulator.Model.Algorithms.ShipsArrange.Extensions;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;
using BattleshipSimulator.Model.Squares.Axes;

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

    private static List<Direction> GetShuffledDirections() => Directions.OrderBy(_ => Random.Next()).ToList();

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
                foreach (var direction in GetShuffledDirections())
                {
                    var endCoordinates = startCoordinates.GetEndCoordinates(direction, ship.Size);
                    if (endCoordinates.IsValid(maxOrdinate, maxAbscissa) is false)
                    {
                        continue;
                    }

                    var coordinates = Coordinates.GetCoordinatesBetween(startCoordinates, endCoordinates);

                    var placeShipResult = squares.PlaceShip(coordinates, ship);
                    if (placeShipResult.Success)
                    {
                        placingShipInProgress = false;
                        break;
                    }
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