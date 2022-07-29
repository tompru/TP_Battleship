using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Ships.Metadata;

public record ShipDamageTaken(int Value) : IntValueObject<ShipDamageTaken>(Value)
{
    private const int NoDamage = 0;
    private const int DamageValue = 1;

    public static ShipDamageTaken Zero => ShipDamageTaken.From(NoDamage);

    public ShipDamageTaken IncreaseDamage()
    {
        var damageTaken = Value;
        damageTaken += DamageValue;
        return ShipDamageTaken.From(damageTaken);
    }
}