using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public record Cruiser : Ship
{
    public override ShipSize Size => ShipSize.From(Consts.ShipSizes.CruiserSize);
}