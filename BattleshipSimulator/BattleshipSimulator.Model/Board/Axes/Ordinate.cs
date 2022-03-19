using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board.Axes;

public record Ordinate(int Value) : IntValueObject<Ordinate>(Value);