using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Ships.Metadata;

public record ShipSize(int Value) : IntValueObject<ShipSize>(Value);