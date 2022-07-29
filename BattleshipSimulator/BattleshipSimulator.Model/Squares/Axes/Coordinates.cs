namespace BattleshipSimulator.Model.Squares.Axes;

public record Coordinates(Ordinate Ordinate, Abscissa Abscissa)
{
    public const int MinAxisValue = 1;

    public bool IsValid(int boardSize)
    {
        return Ordinate.Value <= boardSize && Ordinate >= MinAxisValue &&
               Abscissa.Value <= boardSize && Abscissa >= MinAxisValue;
    }

    public static List<Coordinates> GetCoordinatesBetween(Coordinates start, Coordinates end) =>
        start.Ordinate == end.Ordinate
            ? FillAbscissaGap(start, end)
            : FillOrdinateGap(start, end);


    private static List<Coordinates> FillOrdinateGap(Coordinates start, Coordinates end)
    {
        var coordinates = new List<Coordinates> { start, end };

        var minOrdinate = coordinates.Min(x => x.Ordinate.Value);
        var maxOrdinate = coordinates.Max(x => x.Ordinate.Value);
        var ordinateDiff = maxOrdinate - minOrdinate;
        var gap = Enumerable.Range(minOrdinate + 1, ordinateDiff - 1);
        coordinates.AddRange(
            gap.Select(ordinate => new Coordinates(Ordinate.From(ordinate), start.Abscissa)));

        return coordinates;
    }

    private static List<Coordinates> FillAbscissaGap(Coordinates start, Coordinates end)
    {
        var coordinates = new List<Coordinates> { start, end };

        var minAbscissa = coordinates.Min(x => x.Abscissa.Value);
        var maxAbscissa = coordinates.Max(x => x.Abscissa.Value);
        var abscissaDiff = maxAbscissa - minAbscissa;
        var gap = Enumerable.Range(minAbscissa + 1, abscissaDiff - 1);
        coordinates.AddRange(
            gap.Select(abscissa => new Coordinates(start.Ordinate, Abscissa.From(abscissa))));

        return coordinates;
    }
};