using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Model.Board;

public class Board
{
    public Board()
    {
        Ships = new BoardShips();
        Squares = new BoardSquares();
    }

    public BoardSquares Squares { get; }
    public BoardShips Ships { get; }
}