using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares;

namespace BattleshipSimulator.Model.Boards;

public class Board
{
    private readonly BoardSize _size = BoardSize.From(10);

    public Board()
    {
        Ships = new BoardShips();
        Squares = new BoardSquares(_size);
    }

    public BoardSquares Squares { get; }
    public BoardShips Ships { get; }

    public OperationResult PlaceShips()
    {
        if (Squares.Values.Any(x => x.IsOccupied))
        {
            return new ErrorResult("Ships are already placed on board.");
        }
        ShipsArranger.ArrangeRandomly(Ships, Squares);
        return new SuccessResult();
    }
}