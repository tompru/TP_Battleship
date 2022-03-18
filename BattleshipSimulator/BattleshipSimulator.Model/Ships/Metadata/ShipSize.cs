using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Ships.Metadata;

public record ShipSize(short Value) : ShortValueObject<ShipSize>(Value);