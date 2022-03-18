using System.Linq;
using BattleshipSimulator.Model.Ships;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class BoardShipsTests
{
    [Fact]
    public void WhenBoardShips_IsCreated_ThenValuesShouldNotBeEmpty()
    {
        var boardShips = new BoardShips();

        boardShips.Values.Should().NotBeEmpty();
    }

    [Fact]
    public void WhenBoardShips_IsCreated_ThenValuesShouldContainFiveDestroyers()
    {
        var boardShips = new BoardShips();

        var destroyers = boardShips.Values.Where(x => x is Destroyer);

        destroyers.Count().Should().Be(5);
    }

    [Fact]
    public void WhenBoardShips_IsCreated_ThenValuesShouldContainFourSubmarines()
    {
        var boardShips = new BoardShips();

        var submarines = boardShips.Values.Where(x => x is Submarine);

        submarines.Count().Should().Be(4);
    }

    [Fact]
    public void WhenBoardShips_IsCreated_ThenValuesShouldContainThreeCruisers()
    {
        var boardShips = new BoardShips();

        var cruisers = boardShips.Values.Where(x => x is Cruiser);

        cruisers.Count().Should().Be(3);
    }

    [Fact]
    public void WhenBoardShips_IsCreated_ThenValuesShouldContainTwoBattleships()
    {
        var boardShips = new BoardShips();

        var battleships = boardShips.Values.Where(x => x is Battleship);

        battleships.Count().Should().Be(2);
    }

    [Fact]
    public void WhenBoardShips_IsCreated_ThenValuesShouldContainOneCarrier()
    {
        var boardShips = new BoardShips();

        var carriers = boardShips.Values.Where(x => x is Carrier);

        carriers.Count().Should().Be(1);
    }
}