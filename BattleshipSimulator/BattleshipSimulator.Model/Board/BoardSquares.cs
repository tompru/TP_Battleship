using BattleshipSimulator.Model.Board.Axes;

namespace BattleshipSimulator.Model.Board;

public class BoardSquares
{
    private const short AxisMinValue = 1;
    private const short AxisMaxValue = 10;

    public IReadOnlyList<Square> Values { get; } = InitializeBoardSquares();
    
    private static List<Square> InitializeBoardSquares()
    {
        var boardSquares = new List<Square>();

        for (var ordinate = AxisMinValue; ordinate <= AxisMaxValue; ordinate++)
        {
            for (var abscissa = AxisMinValue; abscissa <= AxisMaxValue; abscissa++)
            {
                var coordinates = new Coordinates(Ordinate.From(ordinate), Abscissa.From(abscissa));
                var square = new Square(coordinates);
                boardSquares.Add(square);
            }
        }

        return boardSquares;
    }
}