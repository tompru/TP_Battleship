using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Boards;

public record BoardSize(int Value) : IntValueObject<BoardSize>(Value);