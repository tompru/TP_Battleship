﻿using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public record Carrier : Ship
{
    public override ShipSize Size => ShipSize.From(Consts.ShipSizes.CarrierSize);
}