namespace BattleshipSimulator.Model.ValueObjects;

public record IntValueObject<TThis>(int Value) : ValueObject<TThis, int>(Value);