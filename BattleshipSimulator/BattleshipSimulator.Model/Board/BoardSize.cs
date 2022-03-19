using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Board;

public record BoardSize(int Value) : IntValueObject<BoardSize>(Value);