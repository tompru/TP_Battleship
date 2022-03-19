using BattleshipSimulator.Model.Ships;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class ShipTests
{
    [Fact]
    public void WhenShip_IsCreated_ThenShipIdShouldNotBeNull()
    {
        var ship = new Carrier();

        ship.Id.Should().NotBeNull();
    }

    [Fact]
    public void WhenShip_IsCreated_ThenShipIdValueShouldNotBeEmpty()
    {
        var ship = new Carrier();

        ship.Id.Value.Should().NotBeEmpty();
    }

    [Fact]
    public void WhenShip_IsCreated_ThenShipDamageTakenShouldNotBeNull()
    {
        var ship = new Carrier();

        ship.DamageTaken.Should().NotBeNull();
    }

    [Fact]
    public void WhenShip_IsCreated_ThenShipDamageTakenValueShouldBeNone()
    {
        var ship = new Carrier();

        ship.DamageTaken.Value.Should().Be(0);
    }

    [Fact]
    public void WhenShip_IsHit_ThenShipDamageTakenValueShouldBeIncreasedByOne()
    {
        var ship = new Carrier();
        var initialDamageTakenValue = ship.DamageTaken.Value;

        var hitResult = ship.Hit();

        var expectedDamageTakenValue = initialDamageTakenValue += 1;

        hitResult.Success.Should().BeTrue();
        ship.DamageTaken.Value.Should().Be(expectedDamageTakenValue);
    }

    [Fact]
    public void WhenShipDamageTaken_EqualsShipSize_ThenShipShouldBeSunk()
    {
        var ship = new Carrier();

        for (var i = 0; i < ship.Size.Value; i++)
        {
            ship.Hit();
        }

        ship.IsSunk.Should().BeTrue();
    }

    [Fact]
    public void WhenShip_IsSunk_ThenShipCannotTakeMoreDamage()
    {
        var ship = new Carrier();

        for (var i = 0; i < ship.Size.Value; i++)
        {
            ship.Hit();
        }

        var hitResult = ship.Hit();

        hitResult.Failure.Should().BeTrue();
        ship.IsSunk.Should().BeTrue();
    }
}