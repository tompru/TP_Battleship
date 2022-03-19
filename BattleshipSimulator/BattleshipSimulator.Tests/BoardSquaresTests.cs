using System.Linq;
using BattleshipSimulator.Model.Board;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class BoardSquaresTests
{
    [Fact]
    public void WhenBoardSquares_IsCreated_ThenValuesShouldNotBeEmpty()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        boardSquares.Values.Should().NotBeEmpty();
    }

    [Fact]
    public void WhenBoardSquares_IsCreated_ThenValuesShouldContainOnlyUniqueCoordinates()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var coordinatesHashSet = boardSquares.Values.Select(x => x.Coordinates).ToHashSet();

        boardSquares.Values.Count.Should().Be(coordinatesHashSet.Count);
    }

    [Fact]
    public void WhenBoardSquares_IsCreated_ThenOrdinatesShouldBeSequential()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var orderedOrdinatesValues = boardSquares.Values
            .Select(x => (int)x.Coordinates.Ordinate.Value)
            .OrderBy(x => x)
            .ToHashSet();

        var ordinatesAreInSequence = orderedOrdinatesValues
            .SequenceEqual(Enumerable.Range(1, orderedOrdinatesValues.Count));

        ordinatesAreInSequence.Should().BeTrue();
    }

    [Fact]
    public void WhenBoardSquares_IsCreated_ThenAbscissasShouldBeSequential()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var orderedOrdinatesValues = boardSquares.Values
            .Select(x => (int)x.Coordinates.Abscissa.Value)
            .OrderBy(x => x)
            .ToHashSet();

        var ordinatesAreInSequence = orderedOrdinatesValues
            .SequenceEqual(Enumerable.Range(1, orderedOrdinatesValues.Count));

        ordinatesAreInSequence.Should().BeTrue();
    }
}