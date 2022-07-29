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
        var boardSquares = new PrimaryBoardSquares(size);

        foreach (var ship in ships.Values)
        {
            PlaceShipOnBoardSquares(ship, boardSquares, size);
        }

        return boardSquares;
    }

    private static void PlaceShipOnBoardSquares(Ship ship, PrimaryBoardSquares boardSquares, BoardSize size)
    {
        var placingShipInProgress = true;
        while (placingShipInProgress)
        {
            var startCoordinates = PickRandomCoordinates(size);

            foreach (var direction in GetShuffledDirections())
            {
                var endCoordinates = startCoordinates.GetEndCoordinates(direction, ship.Size);
                if (endCoordinates.IsValid(size) is false)
                {
                    continue;
                }

                var coordinates = Coordinates.GetCoordinatesBetween(startCoordinates, endCoordinates);

                var placeShipResult = boardSquares.PlaceShip(coordinates, ship);
                if (placeShipResult.Success)
                {
                    placingShipInProgress = false;
                    break;
                }
            }
        }
    }

    private static Coordinates PickRandomCoordinates(BoardSize size)
    {
        var ordinate = Ordinate.From(Random.Next(Coordinates.MinAxisValue, size + 1));
        var abscissa = Abscissa.From(Random.Next(Coordinates.MinAxisValue, size + 1));
        return new Coordinates(ordinate, abscissa);
    }
}