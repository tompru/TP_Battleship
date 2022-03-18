namespace BattleshipSimulator.Model.ValueObjects;

public record ShortValueObject<TThis>(short Value) : ValueObject<TThis, short>(Value);