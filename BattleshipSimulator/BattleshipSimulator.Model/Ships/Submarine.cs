using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public class Submarine : Ship
{
    public override ShipSize Size => ShipSize.From(3);
}