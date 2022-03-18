using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public record Battleship : Ship
{
    public override ShipSize Size => ShipSize.From(Consts.ShipSizes.BattleshipSize);
}