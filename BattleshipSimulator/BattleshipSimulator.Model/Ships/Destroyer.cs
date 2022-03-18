using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public class Destroyer : Ship
{
    public override ShipSize Size => ShipSize.From(2);
}