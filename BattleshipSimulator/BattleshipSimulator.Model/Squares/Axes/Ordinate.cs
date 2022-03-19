using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Squares.Axes;

public record Ordinate(int Value) : IntValueObject<Ordinate>(Value);