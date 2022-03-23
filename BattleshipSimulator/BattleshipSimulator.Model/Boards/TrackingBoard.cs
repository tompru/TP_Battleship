using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Ships.Metadata;
using BattleshipSimulator.Model.Squares;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Boards;

public sealed class TrackingBoard : Board
{
    private BoardShips? _enemyShips;

    public TrackingBoard()
    {
        Squares = new BoardSquares(Size);
    }

    protected override BoardSquares Squares { get; }

    public OperationResult SetupEnemyShips(BoardShips enemyShips)
    {
        if (_enemyShips is not null)
        {
            return new ErrorResult("Enemy ships are already setup on tracking board.");
        }
        _enemyShips = enemyShips;
        return new SuccessResult();
    }

    public OperationResult<Coordinates> GetCoordinatesToAttack()
    {
#warning TODO: algorythm of picking coordinates to attack
        var coordinares = new Coordinates(Ordinate.From(1), Abscissa.From(1));

        var square = Squares.TryGetByCoordinates(coordinares);
        if (square is null)
        {
            return new ErrorResult<Coordinates>($"Square of coordinates {coordinares} not found.");
        }

        return new SuccessResult<Coordinates>(coordinares);
    }

    public OperationResult MarkAttackedField(Coordinates attackedCoordinates, ShipId? attackedShipId)
    {
        var square = Squares.TryGetByCoordinates(attackedCoordinates);
        if (square is null)
        {
            return new ErrorResult<Coordinates>($"Square of coordinates {attackedCoordinates} not found.");
        }
        var markSquareResult = square.Mark();
        if (markSquareResult.Failure)
        {
            return new ErrorResult<Coordinates>($"Error on marking square on tracking board ({attackedCoordinates}) : {markSquareResult.Message}");
        }

        return TryPlaceAttackedShipOnSquare(square, attackedShipId);
    }

    private OperationResult TryPlaceAttackedShipOnSquare(Square square, ShipId? attackedShipId)
    {
        if (attackedShipId is null)
        {
            return new SuccessResult();
        }

        var placeShipResult = square.PlaceShip(attackedShipId);
        if (placeShipResult.Failure)
        {
            return placeShipResult;
        }

        return _enemyShips!.Hit(attackedShipId);
    }
}