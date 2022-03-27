using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares.Axes;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class TrackingBoardTests
{
    private readonly IHitPropabilityCalculator _hitPropabilityCalculator = new DummyHitPropabilityCalculator();

    [Fact]
    public void WhenTrackingBoard_EnemyShipsAreNotSetup_ThenGetCoordinatesToAttackShouldFail()
    {
        var board = new TrackingBoard(_hitPropabilityCalculator);

        var result = board.GetCoordinatesToAttack();

        result.Success.Should().BeFalse();
    }

    [Fact]
    public void WhenTrackingBoard_EnemyShipsAreSetupMultipleTimes_ThenOperationResultShouldFail()
    {
        var board = new TrackingBoard(_hitPropabilityCalculator);

        var enemyShips = new BoardShips();
        var firstResult = board.SetupEnemyShips(enemyShips);
        var secondResult = board.SetupEnemyShips(enemyShips);

        firstResult.Success.Should().BeTrue();
        secondResult.Success.Should().BeFalse();
    }

    [Fact]
    public void WhenTrackingBoard_EnemyShipsAreSetup_ThenCoordinatesToAttackShouldNotBeNull()
    {
        var board = new TrackingBoard(_hitPropabilityCalculator);

        var enemyShips = new BoardShips();
        board.SetupEnemyShips(enemyShips);

        var result = board.GetCoordinatesToAttack();

        result.Success.Should().BeTrue();
        result.Payload.Should().NotBeNull();
    }

    [Fact]
    public void WhenTrackingBoardCoordinates_DoesntExist_ThenMarkAttackedFieldShouldFail()
    {
        var board = new TrackingBoard(_hitPropabilityCalculator);

        var coordinates = new Coordinates(Ordinate.From(100), Abscissa.From(100));

        var result = board.MarkAttackedField(coordinates, null);

        result.Success.Should().BeFalse();
    }

    [Fact]
    public void WhenTrackingBoardSquare_IsMarkedMultipleTimes_ThenMarkAttackedFieldShouldFail()
    {
        var board = new TrackingBoard(_hitPropabilityCalculator);

        var coordinates = new Coordinates(Ordinate.From(1), Abscissa.From(1));

        var firstResult = board.MarkAttackedField(coordinates, null);
        var secondResult = board.MarkAttackedField(coordinates, null);

        firstResult.Success.Should().BeTrue();
        secondResult.Success.Should().BeFalse();
    }

    [Fact]
    public void WhenTrackingBoardSquare_IsMarkedWithShip_ThenSquareShouldBeOccupied()
    {
        var board = new TrackingBoard(_hitPropabilityCalculator);

        var coordinates = new Coordinates(Ordinate.From(1), Abscissa.From(1));
        var ship = new Destroyer();

        var result = board.MarkAttackedField(coordinates, ship.Id);

        var square = board.Squares.TryGetByCoordinates(coordinates);

        result.Success.Should().BeTrue();
        square.Should().NotBeNull();
        square!.IsMarked.Should().BeTrue();
        square!.IsOccupied.Should().BeTrue();
    }
}