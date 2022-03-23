using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Boards;
using FluentAssertions;
using Xunit;

namespace BattleshipSimulator.Tests;

public class BoardTests
{
    private readonly IShipArranger _arranger = new ShipsRandomArranger();

    [Fact]
    public void WhenBoard_()
    {
        var board = new PrimaryBoard(_arranger);

#warning TODO: Boards public api tests
    }
}