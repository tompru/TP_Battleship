using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board.Coordinates;

public record Abscissa(short Value) : ShortValueObject<Abscissa>(Value);