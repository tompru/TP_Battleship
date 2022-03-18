using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Ships.Metadata;

public record ShipDamageTaken(short Value) : ShortValueObject<ShipDamageTaken>(Value)
{
    private const short NoDamage = 0;
    private const short DamageValue = 1;

    public static ShipDamageTaken CreateWithNoDamage()
    {
        return ShipDamageTaken.From(NoDamage);
    }

    public ShipDamageTaken IncreaseDamage()
    {
        var damageTaken = Value;
        damageTaken += DamageValue;
        return ShipDamageTaken.From(damageTaken);
    }
}