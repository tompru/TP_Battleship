using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Model.Board;

public class Board
{
    private readonly BoardSize _size = BoardSize.From(10);

    public Board()
    {
        Ships = new BoardShips();
        Squares = new BoardSquares(_size);
        Squares.PlaceShips(Ships);
    }

    public BoardSquares Squares { get; }
    public BoardShips Ships { get; }
}