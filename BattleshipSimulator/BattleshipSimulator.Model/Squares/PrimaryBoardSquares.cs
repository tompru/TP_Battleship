using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Squares;

public sealed class PrimaryBoardSquares : BoardSquares
{
    public PrimaryBoardSquares(BoardSize boardSize) : base(boardSize) { }

    public OperationResult PlaceShip(IEnumerable<Coordinates> coordinates, Ship ship)
    {
        var coordinatesList = coordinates.ToList();

        if (coordinatesList.Count != ship.Size.Value)
        {
            return new ErrorResult("Coordinates count doesnt equal ship size.");
        }
        if (CheckIfOccupied(coordinatesList))
        {
            return new ErrorResult("At least one of squares is already occupied.");
        }

        var squaresToPlaceShip = Values.Where(square => coordinatesList.Contains(square.Coordinates));
        foreach (var square in squaresToPlaceShip)
        {
            square.PlaceShip(ship.Id);
        }

        return new SuccessResult();
    }
}