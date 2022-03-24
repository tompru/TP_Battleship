using BattleshipSimulator.Model.Algorithms.Extensions;
using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Algorithms.ShipsArrange;

public class ShipsRandomArranger : IShipArranger
{
    private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

    private static List<Direction> GetShuffledDirections() => Consts.Directions.OrderBy(_ => Random.Next()).ToList();

    public PrimaryBoardSquares Arrange(BoardShips ships, BoardSize size)
    {
        var squares = new PrimaryBoardSquares(size);

        foreach (var ship in ships.Values)
        {
            var placingShipInProgress = true;
            while (placingShipInProgress)
            {
                var startCoordinates = PickRandomCoordinates(size);
                foreach (var direction in GetShuffledDirections())
                {
                    var endCoordinates = startCoordinates.GetEndCoordinates(direction, ship.Size);
                    if (endCoordinates.IsValid(size.Value) is false)
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

        return squares;
    }

    private static Coordinates PickRandomCoordinates(BoardSize size)
    {
        var ordinate = Ordinate.From(Random.Next(Coordinates.MinAxisValue, size.Value + 1));
        var abscissa = Abscissa.From(Random.Next(Coordinates.MinAxisValue, size.Value + 1));
        return new Coordinates(ordinate, abscissa);
    }
}