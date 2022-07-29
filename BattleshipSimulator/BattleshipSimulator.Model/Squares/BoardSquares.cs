using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Squares;

public abstract class BoardSquares
{
    protected readonly IReadOnlyDictionary<Coordinates, Square> _valuesDict;

    protected BoardSquares(BoardSize boardSize)
    {
        _valuesDict = InitializeBoardSquares(boardSize);
    }

    public IReadOnlyList<Square> Values => _valuesDict.Values.ToList();

    public Square? GetByCoordinates(Coordinates coordinates) =>
        _valuesDict.TryGetValue(coordinates, out var square) ? square : default;

    public bool CheckIfOccupied(IEnumerable<Coordinates> coordinates) =>
        coordinates.Any(c => CheckIfOccupied(c));

    public bool CheckIfOccupied(Coordinates coordinates) =>
        _valuesDict.TryGetValue(coordinates, out var square) && square.IsOccupied;

    protected static Dictionary<Coordinates, Square> InitializeBoardSquares(BoardSize boardSize)
    {
        var boardSquares = new List<Square>();

        for (var ordinate = Coordinates.MinAxisValue; ordinate <= boardSize; ordinate++)
        {
            for (var abscissa = Coordinates.MinAxisValue; abscissa <= boardSize; abscissa++)
            {
                var coordinates = new Coordinates(Ordinate.From(ordinate), Abscissa.From(abscissa));
                var square = new Square(coordinates);
                boardSquares.Add(square);
            }
        }

        return boardSquares.ToDictionary(x => x.Coordinates, x => x);
    }
}