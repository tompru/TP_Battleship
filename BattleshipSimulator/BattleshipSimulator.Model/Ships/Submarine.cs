using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public record Submarine : Ship
{
    public override ShipSize Size => ShipSize.From(Consts.ShipSizes.SubmarineSize);
}