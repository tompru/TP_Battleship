namespace BattleshipSimulator.Model.ValueObjects;

public record GuidValueObject<TThis>(Guid Value) : ValueObject<TThis, Guid>(Value);