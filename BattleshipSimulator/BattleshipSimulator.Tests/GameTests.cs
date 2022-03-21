using System.Linq;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Engine;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class GameTests
{
    private readonly IShipArranger _arranger = new ShipsRandomArranger();

    [Fact]
    public void WhenGame_IsCreated_ThenPlayersShouldBeNull()
    {
        var game = new Game(_arranger);

        game.PlayerA.Should().BeNull();
        game.PlayerB.Should().BeNull();
    }

    [Fact]
    public void WhenNewGame_IsSetup_ThenPlayersShouldNotBeNull()
    {
        var game = new Game(_arranger);

        var result = game.SetupNewGame();

        game.PlayerA.Should().NotBeNull();
        game.PlayerB.Should().NotBeNull();
    }

    [Fact]
    public void WhenNewGame_IsSetup_ThenOperationResultShouldSuccess()
    {
        var game = new Game(_arranger);

        var result = game.SetupNewGame();

        result.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenNewGame_IsSetupMultipleTimes_ThenOperationResultShouldSuccess()
    {
        var game = new Game(_arranger);

        var firstResult = game.SetupNewGame();
        var secondResult = game.SetupNewGame();

        firstResult.Success.Should().BeTrue();
        secondResult.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenNewGame_IsSetupManyTimes_ThenShipsAreArrangedDifferently()
    {
        var game = new Game(_arranger);

        game.SetupNewGame();
        var firstGamePlayerAOccupiedCoordinates =
            game.PlayerA!.PrimaryBoard.Squares.Values.Where(x => x.IsOccupied).ToList();

        game.SetupNewGame();
        var secondGamePlayerAOccupiedCoordinates =
            game.PlayerA!.PrimaryBoard.Squares.Values.Where(x => x.IsOccupied).ToList();

        firstGamePlayerAOccupiedCoordinates.Should().NotBeSameAs(secondGamePlayerAOccupiedCoordinates);
    }
}