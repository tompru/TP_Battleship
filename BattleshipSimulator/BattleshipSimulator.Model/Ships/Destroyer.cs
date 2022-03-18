using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public record Destroyer : Ship
{
    public override ShipSize Size => ShipSize.From(Consts.ShipSizes.DestroyerSize);
}