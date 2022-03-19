using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board.Axes;

public record Abscissa(int Value) : IntValueObject<Abscissa>(Value);