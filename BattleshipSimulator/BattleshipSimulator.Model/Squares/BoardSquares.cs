using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Squares;

public abstract class BoardSquares
{
    protected readonly Dictionary<Coordinates, Square> _valuesDict;

    protected BoardSquares(BoardSize boardSize)
    {
        Values = InitializeBoardSquares(boardSize);
        _valuesDict = Values.ToDictionary(x => x.Coordinates, x => x);
    }

    public IReadOnlyList<Square> Values { get; }

    public Square? TryGetByCoordinates(Coordinates coordinates) =>
        _valuesDict.TryGetValue(coordinates, out var square) ? square : default;

    public bool CheckIfOccupied(IEnumerable<Coordinates> coordinates) =>
        coordinates.Any(c => CheckIfOccupied(c));

    public bool CheckIfOccupied(Coordinates coordinates) =>
        _valuesDict.TryGetValue(coordinates, out var square) && square.IsOccupied;

    protected static List<Square> InitializeBoardSquares(BoardSize boardSize)
    {
        var boardSquares = new List<Square>();

        for (var ordinate = Coordinates.MinAxisValue; ordinate <= boardSize.Value; ordinate++)
        {
            for (var abscissa = Coordinates.MinAxisValue; abscissa <= boardSize.Value; abscissa++)
            {
                var coordinates = new Coordinates(Ordinate.From(ordinate), Abscissa.From(abscissa));
                var square = new Square(coordinates);
                boardSquares.Add(square);
            }
        }

        return boardSquares;
    }
}