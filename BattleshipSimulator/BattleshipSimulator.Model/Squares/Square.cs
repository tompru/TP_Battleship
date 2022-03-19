using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships.Metadata;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Squares;

public class Square
{
    public Square(Coordinates coordinates)
    {
        Coordinates = coordinates;
    }
    public Coordinates Coordinates { get; }
    public ShipId? ShipId { get; private set; }
    public bool IsOccupied => ShipId is not null;

    public OperationResult PlaceShip(ShipId shipId)
    {
        if (IsOccupied)
        {
            return new ErrorResult("Field is already occupied.");
        }

        ShipId = shipId;
        return new SuccessResult();
    }
}