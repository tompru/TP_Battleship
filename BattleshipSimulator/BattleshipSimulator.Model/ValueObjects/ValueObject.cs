using System.Linq.Expressions;
using System.Reflection;

namespace BattleshipSimulator.Model.ValueObjects;

public abstract record ValueObject<TThis, TValue>(TValue Value)
{
    private static readonly Func<TValue, TThis> Creator = CreateCreator();

    public static TThis From(TValue value)
    {
        return Creator(value);
    }

    private static Func<TValue, TThis> CreateCreator()
    {
        var ctor = typeof(TThis).GetTypeInfo().DeclaredConstructors.First();
        var parameter = Expression.Parameter(typeof(TValue), "p");
        var creatorExpression = Expression.Lambda<Func<TValue, TThis>>(
            Expression.New(ctor, new Expression[] { parameter }), parameter);
        return creatorExpression.Compile();
    }
}