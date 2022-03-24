using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Algorithms.ShipsArrange;

public interface IShipArranger
{
    PrimaryBoardSquares Arrange(BoardShips ships, BoardSize size);
}