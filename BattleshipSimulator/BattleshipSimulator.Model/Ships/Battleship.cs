using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public class Battleship : Ship
{
    public override ShipSize Size => ShipSize.From(4);
}