using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Squares.Axes;

public record Abscissa(int Value) : IntValueObject<Abscissa>(Value);