using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board.Axes;

public record Ordinate(short Value) : ShortValueObject<Ordinate>(Value);