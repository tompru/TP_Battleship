using System.Linq;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Boards;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class BoardTests
{
    private readonly IShipArranger _arranger = new ShipsRandomArranger();

    [Fact]
    public void WhenBoard_IsCreated_ThenShipsAndSquaresShouldNotBeEmpty()
    {
        var board = new PrimaryBoard(_arranger);

        board.Ships.Values.Should().NotBeEmpty();
        board.Squares.Values.Should().NotBeEmpty();
    }

    [Fact]
    public void WhenPrimaryBoard_IsCreated_ThenSummaryShipSizesShouldEqualsOccupiedSquaresCount()
    {
        var board = new PrimaryBoard(_arranger);

        var summaryShipSizes = board.Ships.Values.Sum(x => x.Size.Value);
        var occupiedSquaresCount = board.Squares.Values.Count(x => x.IsOccupied);

        summaryShipSizes.Should().Be(occupiedSquaresCount);
    }
}