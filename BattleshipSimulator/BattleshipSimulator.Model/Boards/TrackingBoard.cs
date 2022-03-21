using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Boards;

public class TrackingBoard : Board
{
    private BoardShips? _enemyShips;

    public TrackingBoard()
    {
        Squares = new BoardSquares(Size);
    }

    public override BoardSquares Squares { get; }

    public OperationResult SetupEnemyShips(BoardShips enemyShips)
    {
        if (_enemyShips is not null)
        {
            return new ErrorResult("Enemy ships are already setup on tracking board.");
        }
        _enemyShips = enemyShips;
        return new SuccessResult();
    }
}