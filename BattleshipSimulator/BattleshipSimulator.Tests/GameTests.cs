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
        var game = new Game();

        game.PlayerA.Should().BeNull();
        game.PlayerB.Should().BeNull();
    }

    [Fact]
    public void WhenNewGame_IsSetup_ThenPlayersShouldNotBeNull()
    {
        var game = new Game();

        var result = game.SetupNewGame(_arranger);

        game.PlayerA.Should().NotBeNull();
        game.PlayerB.Should().NotBeNull();
    }

    [Fact]
    public void WhenNewGame_IsSetup_ThenOperationResultShouldSuccess()
    {
        var game = new Game();

        var result = game.SetupNewGame(_arranger);

        result.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenNewGame_IsSetupMultipleTimes_ThenOperationResultShouldSuccess()
    {
        var game = new Game();

        var firstResult = game.SetupNewGame(_arranger);
        var secondResult = game.SetupNewGame(_arranger);

        firstResult.Success.Should().BeTrue();
        secondResult.Success.Should().BeTrue();
    }
}