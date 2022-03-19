using System.Linq;
using BattleshipSimulator.Model.Board;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class BoardTests
{
    [Fact]
    public void WhenBoard_IsCreated_ThenShipsAndSquaresShouldNotEmpty()
    {
        var board = new Board();

        board.Ships.Values.Should().NotBeEmpty();
        board.Squares.Values.Should().NotBeEmpty();
    }

    [Fact]
    public void WhenBoard_IsCreated_ThenNoSquaresShouldBeOccupied()
    {
        var board = new Board();

        var isAnySquareOcupied = board.Squares.Values.Any(x => x.IsOccupied);

        isAnySquareOcupied.Should().BeFalse();
    }

    [Fact]
    public void WhenBoardSquares_AreNotOccupied_ThenPlaceShipsShouldSuccess()
    {
        var board = new Board();

        var placeShipsResult = board.PlaceShips();

        placeShipsResult.Success.Should().BeTrue();
    }

    [Fact]
    public void WhenBoardSquares_AreOccupied_ThenPlaceShipsShouldFail()
    {
        var board = new Board();

        var firstResult = board.PlaceShips();
        var secondResult = board.PlaceShips();

        firstResult.Success.Should().BeTrue();
        secondResult.Failure.Should().BeTrue();
    }

    [Fact]
    public void WhenShips_ArePlacesAtBoard_ThenSummaryShipSizesShouldEqualsOccupiedSquaresCount()
    {
        var board = new Board();

        board.PlaceShips();

        var summaryShipSizes = board.Ships.Values.Sum(x => x.Size.Value);
        var occupiedSquaresCount = board.Squares.Values.Count(x => x.IsOccupied);

        summaryShipSizes.Should().Be(occupiedSquaresCount);
    }
}