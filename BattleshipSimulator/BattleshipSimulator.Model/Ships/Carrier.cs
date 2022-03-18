using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public class Carrier : Ship
{
    public override ShipSize Size => ShipSize.From(5);
}