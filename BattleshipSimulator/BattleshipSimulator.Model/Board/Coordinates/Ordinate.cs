using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board.Coordinates;

public record Ordinate(short Value) : ShortValueObject<Ordinate>(Value);