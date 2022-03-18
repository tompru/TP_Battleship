using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board.Axes;

public record Abscissa(short Value) : ShortValueObject<Abscissa>(Value);