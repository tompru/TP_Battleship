using BattleshipSimulator.Model.Board;
using BattleshipSimulator.Model.Board.Axes;
using BattleshipSimulator.Model.Ships.Metadata;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class SquareTests
{
    [Fact]
    public void WhenNewSquare_IsCreated_ThenShipIdShouldBeNull()
    {
        var square = CreateSquare();

        square.ShipId.Should().BeNull();
    }

    [Fact]
    public void WhenNewSquare_IsCreated_ThenIsOccupiedShouldBeFalse()
    {
        var square = CreateSquare();

        square.IsOccupied.Should().BeFalse();
    }

    [Fact]
    public void WhenNewSquare_IsCreated_ThenPlaceShipShouldSuccess()
    {
        var square = CreateSquare();

        var shipId = ShipId.Create();
        var placeShipResult = square.PlaceShip(shipId);

        placeShipResult.Success.Should().BeTrue();
        square.ShipId.Should().Be(shipId);
        square.IsOccupied.Should().BeTrue();
    }

    [Fact]
    public void WhenSquare_IsAlreadyOccupied_ThenPlaceShipShouldFail()
    {
        var square = CreateSquare();

        var initialShipId = ShipId.Create();
        square.PlaceShip(initialShipId);

        var newShipId = ShipId.Create();
        var placeShipResult = square.PlaceShip(newShipId);

        placeShipResult.Success.Should().BeFalse();
        square.ShipId.Should().Be(initialShipId);
        square.IsOccupied.Should().BeTrue();
    }

    private static Square CreateSquare()
    {
        var coordinates = new Coordinates(Ordinate.From(1), Abscissa.From(1));
        var square = new Square(coordinates);
        return square;
    }
}