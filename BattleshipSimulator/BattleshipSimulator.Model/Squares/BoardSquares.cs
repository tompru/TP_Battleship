﻿using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;
using BattleshipSimulator.Model.Squares.Axes;

namespace BattleshipSimulator.Model.Squares;

public class BoardSquares
{
    private readonly Dictionary<Coordinates, Square> _valuesDict;

    public BoardSquares(BoardSize boardSize)
    {
        Values = InitializeBoardSquares(boardSize);
        _valuesDict = Values.ToDictionary(x => x.Coordinates, x => x);
    }

    public IReadOnlyList<Square> Values { get; }

    public bool CheckIfOccupied(IEnumerable<Coordinates> coordinates) =>
        coordinates.Any(c => CheckIfOccupied(c));

    public bool CheckIfOccupied(Coordinates coordinates) =>
        _valuesDict.TryGetValue(coordinates, out var square) && square.IsOccupied;

    public OperationResult PlaceShip(IEnumerable<Coordinates> coordinates, Ship ship)
    {
        var coordinatesList = coordinates.ToList();

        if (coordinatesList.Count != ship.Size.Value)
        {
            return new ErrorResult("Coordinates count doesnt equal ship size.");
        }
        if (CheckIfOccupied(coordinatesList))
        {
            return new ErrorResult("At least one of squares is already occupied.");
        }

        var squaresToPlaceShip = Values.Where(square => coordinatesList.Contains(square.Coordinates));
        foreach (var square in squaresToPlaceShip)
        {
            square.PlaceShip(ship.Id);
        }

        return new SuccessResult();
    }


    private static List<Square> InitializeBoardSquares(BoardSize boardSize)
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