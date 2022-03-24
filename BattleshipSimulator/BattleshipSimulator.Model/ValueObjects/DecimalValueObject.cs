namespace BattleshipSimulator.Model.ValueObjects;

public record DecimalValueObject<TThis>(decimal Value) : ValueObject<TThis, decimal>(Value);