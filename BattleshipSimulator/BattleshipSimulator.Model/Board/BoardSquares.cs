using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Board.Axes;
using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Model.Board;

public class BoardSquares
{
    public BoardSquares(BoardSize boardSize)
    {
        Values = InitializeBoardSquares(boardSize);
    }

    public IReadOnlyList<Square> Values { get; }

    public void PlaceShips(BoardShips ships) => ShipsArranger.ArrangeRandomly(ships, this);

    private static List<Square> InitializeBoardSquares(BoardSize boardSize)
    {
        var boardSquares = new List<Square>();

        for (short ordinate = 1; ordinate <= boardSize.Value; ordinate++)
        {
            for (short abscissa = 1; abscissa <= boardSize.Value; abscissa++)
            {
                var coordinates = new Coordinates(Ordinate.From(ordinate), Abscissa.From(abscissa));
                var square = new Square(coordinates);
                boardSquares.Add(square);
            }
        }

        return boardSquares;
    }
}