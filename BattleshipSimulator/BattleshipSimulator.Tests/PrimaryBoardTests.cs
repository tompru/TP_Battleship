using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Squares.Axes;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class PrimaryBoardTests
{
    private readonly IShipArranger _arranger = new ShipsRandomArranger();

    [Fact]
    public void WhenPrimaryBoardSquare_IsMarkedOnce_ThenOperationShouldSuccess()
    {
        var board = new PrimaryBoard(_arranger);

        var coordinates = new Coordinates(Ordinate.From(1), Abscissa.From(1));

        var result = board.MarkHit(coordinates);

        result.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenPrimaryBoardSquare_IsMarkedMultipleTimes_ThenOperationShouldFail()
    {
        var board = new PrimaryBoard(_arranger);

        var coordinates = new Coordinates(Ordinate.From(1), Abscissa.From(1));

        var firstResult = board.MarkHit(coordinates);
        var secondResult = board.MarkHit(coordinates);

        firstResult.Success.Should().BeTrue();
        secondResult.Success.Should().BeFalse();
    }

    [Fact]
    public void WhenPrimaryBoardSquare_DoesntExist_ThenMarkHitShouldFail()
    {
        var board = new PrimaryBoard(_arranger);

        var coordinates = new Coordinates(Ordinate.From(100), Abscissa.From(100));

        var result = board.MarkHit(coordinates);

        result.Success.Should().BeFalse();
    }
}