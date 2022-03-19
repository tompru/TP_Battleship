using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board;

public record BoardSize(short Value) : ShortValueObject<BoardSize>(Value);