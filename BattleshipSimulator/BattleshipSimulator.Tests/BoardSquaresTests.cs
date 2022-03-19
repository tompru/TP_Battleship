using System.Collections.Generic;
using System.Linq;
using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;
using BattleshipSimulator.Model.Squares.Axes;
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
            .Select(x => x.Coordinates.Ordinate.Value)
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
            .Select(x => x.Coordinates.Abscissa.Value)
            .OrderBy(x => x)
            .ToHashSet();

        var ordinatesAreInSequence = orderedOrdinatesValues
            .SequenceEqual(Enumerable.Range(1, orderedOrdinatesValues.Count));

        ordinatesAreInSequence.Should().BeTrue();
    }

    [Fact]
    public void WhenCoordinates_AreEmpty_ThenShipPlacementShouldFail()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var ship = new Destroyer();

        var result = boardSquares.PlaceShip(new List<Coordinates>(), ship);

        result.Failure.Should().BeTrue();
    }

    [Fact]
    public void WhenCoordinatesCount_IsNotEqualToShipSize_ThenShipPlacementShouldFail()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var ship = new Destroyer();

        var coordinates = new List<Coordinates>
        {
            new(Ordinate.From(2), Abscissa.From(1)),
            new(Ordinate.From(3), Abscissa.From(1)),
            new(Ordinate.From(4), Abscissa.From(1)),
        };

        var result = boardSquares.PlaceShip(coordinates, ship);

        result.Failure.Should().BeTrue();
    }

    [Fact]
    public void WhenSquares_AreNotOccupied_ThenShipPlacementShouldSuccess()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var ship = new Destroyer();
        var coordinates = new List<Coordinates>
        {
            new(Ordinate.From(2), Abscissa.From(1)),
            new(Ordinate.From(3), Abscissa.From(1)),
        };

        var result = boardSquares.PlaceShip(coordinates, ship);
        var isShipPlaced = boardSquares.Values
            .Where(square => coordinates.Contains(square.Coordinates))
            .All(x=>x.ShipId == ship.Id);

        result.Success.Should().BeTrue();
        isShipPlaced.Should().BeTrue();

    }

    [Fact]
    public void WhenAtLeastOneOfSquares_IsOccupied_ThenShipPlacementShouldFail()
    {
        var boardSquares = new BoardSquares(BoardSize.From(10));

        var firstDestroyer = new Destroyer();
        var firstDestroyerCoordinates = new List<Coordinates>
        {
            new(Ordinate.From(2), Abscissa.From(1)),
            new(Ordinate.From(3), Abscissa.From(1)),
        };

        var secondDestroyer = new Destroyer();
        var secondDestroyerCoordinates = new List<Coordinates>
        {
            new(Ordinate.From(2), Abscissa.From(1)),
            new(Ordinate.From(2), Abscissa.From(2)),
        };

        var firstPlacementResult = boardSquares.PlaceShip(firstDestroyerCoordinates, firstDestroyer);
        var secondPlacementResult = boardSquares.PlaceShip(secondDestroyerCoordinates, secondDestroyer);

        firstPlacementResult.Success.Should().BeTrue();
        secondPlacementResult.Failure.Should().BeTrue();
    }
}