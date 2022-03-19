using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Boards;

public class TrackingBoard : Board
{
    private readonly BoardShips _enemyShips;

    public TrackingBoard(BoardShips enemyShips)
    {
        _enemyShips = enemyShips;
        Squares = new BoardSquares(Size);
    }

    public override BoardSquares Squares { get; }
}