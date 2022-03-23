using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Boards;

public abstract class Board
{
    protected static readonly BoardSize Size = BoardSize.From(10);

    protected abstract BoardSquares Squares { get; }
}