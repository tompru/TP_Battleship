using BattleshipSimulator.Model.ValueObjects;

namespace BattleshipSimulator.Model.Algorithms.HitPropability;

public record HitPropability(decimal Value) : DecimalValueObject<HitPropability>(Value)
{
    public static HitPropability Zero => HitPropability.From(decimal.Zero);
}