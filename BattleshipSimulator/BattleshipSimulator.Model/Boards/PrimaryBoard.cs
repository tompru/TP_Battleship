using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Boards;

public class PrimaryBoard : Board
{
    public PrimaryBoard(IShipArranger arranger)
    {
        Ships = new BoardShips();
        Squares = arranger.Arrange(Ships, Size);
    }

    public BoardShips Ships { get; }
    public override BoardSquares Squares { get; }
}