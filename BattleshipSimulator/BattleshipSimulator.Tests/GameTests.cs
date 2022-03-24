using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Engine;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class GameTests
{
    private readonly IShipArranger _arranger = new ShipsRandomArranger();
    private readonly IHitPropabilityCalculator _hitPropabilityCalculator = new DummyHitPropabilityCalculator();

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

        var result = game.SetupNewGame(_arranger, _hitPropabilityCalculator);

        game.PlayerA.Should().NotBeNull();
        game.PlayerB.Should().NotBeNull();
    }

    [Fact]
    public void WhenNewGame_IsSetup_ThenOperationResultShouldSuccess()
    {
        var game = new Game();

        var result = game.SetupNewGame(_arranger, _hitPropabilityCalculator);

        result.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenNewGame_IsSetupMultipleTimes_ThenOperationResultShouldSuccess()
    {
        var game = new Game();

        var firstResult = game.SetupNewGame(_arranger, _hitPropabilityCalculator);
        var secondResult = game.SetupNewGame(_arranger, _hitPropabilityCalculator);

        firstResult.Success.Should().BeTrue();
        secondResult.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenGame_IsNotSetup_ThenPlayRoundShouldFail()
    {
        var game = new Game();

        var playRoundResult = game.PlayRound();

        playRoundResult.Success.Should().BeFalse();
    }

    [Fact]
    public void WhenGame_IsSetup_ThenPlayRoundShouldSuccess()
    {
        var game = new Game();

        game.SetupNewGame(_arranger, _hitPropabilityCalculator);

        var playRoundResult = game.PlayRound();

        playRoundResult.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenGame_IsPlayed_ThenOneOfPlayersShouldWin()
    {
        var game = new Game();
        game.SetupNewGame(_arranger, _hitPropabilityCalculator);

        var maxRoundsNumbers = 100;
        var playedRounds = 0;

        var playRoundsSuccess = true;
        while (maxRoundsNumbers >= playedRounds)
        {
            var result = game.PlayRound();
            if (result.Failure)
            {
                playRoundsSuccess = false;
            }
            playedRounds++;
            if (game.PlayerB!.HasLost || game.PlayerA!.HasLost)
            {
                break;
            }
        }

        var success = (game.PlayerB!.HasLost || game.PlayerA!.HasLost) && playRoundsSuccess;
        success.Should().BeTrue();
    }
}