using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Ships.Metadata;
using BattleshipSimulator.Model.Squares;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Boards;

public sealed class TrackingBoard : Board
{
    private readonly IHitPropabilityCalculator _hitPropabilityCalculator;
    private readonly TrackingBoardSquares _squares;

    private BoardShips? _enemyShips;

    public IReadOnlyList<CoordinatesHitPropability>? HitPropabilities { get; private set; }

    public TrackingBoard(IHitPropabilityCalculator hitPropabilityCalculator)
    {
        _squares = new TrackingBoardSquares(Size);
        _hitPropabilityCalculator = hitPropabilityCalculator;
    }

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
        if (_enemyShips is null)
        {
            return new ErrorResult<Coordinates>("Enemy ships are not setup yet.");
        }

        HitPropabilities = _hitPropabilityCalculator.Calculate(_enemyShips, _squares);

        var maxPropability = HitPropabilities.Max(x => x.HitPropability.Value);
        var shuffledCoordinatesWithMaxPropability = HitPropabilities
            .Where(x => x.HitPropability.Value == maxPropability)
            .OrderBy(_ => Guid.NewGuid());

        var coordinares = shuffledCoordinatesWithMaxPropability.First().Coordinates;

        var square = _squares.TryGetByCoordinates(coordinares);
        if (square is null)
        {
            return new ErrorResult<Coordinates>($"Square of coordinates {coordinares} not found.");
        }

        return new SuccessResult<Coordinates>(coordinares);
    }

    public OperationResult MarkAttackedField(Coordinates attackedCoordinates, ShipId? attackedShipId)
    {
        var square = _squares.TryGetByCoordinates(attackedCoordinates);
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

        return new SuccessResult();
    }
}