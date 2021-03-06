using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public abstract class Ship
{
    protected Ship()
    {
        Id = ShipId.Create();
        DamageTaken = ShipDamageTaken.Zero;
    }

    public ShipId Id { get; }
    public abstract ShipSize Size { get; }
    public ShipDamageTaken DamageTaken { get; private set; }
    public bool IsSunk => DamageTaken >= Size;

    public OperationResult Hit()
    {
        if (IsSunk)
        {
            return new ErrorResult("Cannot deal more damage - ship is already sunk.");
        }
        DamageTaken = DamageTaken.IncreaseDamage();
        return new SuccessResult();
    }
}