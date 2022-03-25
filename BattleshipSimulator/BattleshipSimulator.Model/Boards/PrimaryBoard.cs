using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Ships.Metadata;
using BattleshipSimulator.Model.Squares;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Boards;

public sealed class PrimaryBoard : Board
{
    private readonly PrimaryBoardSquares _squares;
    public PrimaryBoard(IShipArranger arranger)
    {
        Ships = new BoardShips();
        _squares = arranger.Arrange(Ships, Size);
    }

    public BoardShips Ships { get; }

    public OperationResult<ShipId?> MarkHit(Coordinates coordinates)
    {
        var field = _squares.TryGetByCoordinates(coordinates);
        if (field is null)
        {
            return new ErrorResult<ShipId?>($"Square of coordinates {coordinates} not found.");
        }
        var markResult = field.Mark();
        if (markResult.Failure)
        {
            return new ErrorResult<ShipId?>(markResult.Message);
        }

        if (field.ShipId is not null)
        {
            var shipHitResult = Ships.Hit(field.ShipId);
            if (shipHitResult.Failure)
            {
                return new ErrorResult<ShipId?>(shipHitResult.Message);
            }
        }
        
        return new SuccessResult<ShipId?>(field.ShipId);
    }
}