using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Ships.Metadata;

public record ShipId(Guid Value) : GuidValueObject<ShipId>(Value)
{
    public static ShipId Create() => ShipId.From(Guid.NewGuid());
}