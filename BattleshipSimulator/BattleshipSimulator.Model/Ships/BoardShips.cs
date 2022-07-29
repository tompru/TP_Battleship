using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships.Metadata;

namespace BattleshipSimulator.Model.Ships;

public class BoardShips
{
    private const int DestroyersCount = 5;
    private const int SubmarinesCount = 4;
    private const int CruisersCount = 3;
    private const int BattleshipsCount = 2;
    private const int CarriersCount = 1;

    public IReadOnlyList<Ship> Values { get; } = InitializeBoardShips();

    public OperationResult Hit(ShipId shipId)
    {
        var ship = Values.SingleOrDefault(x => x.Id == shipId);
        if (ship is null)
        {
            return new ErrorResult($"Ship of Id {shipId.Value} not found.");
        }

        return ship.Hit();
    }

    private static List<Ship> InitializeBoardShips()
    {
        var boardShips = new List<Ship>();

        boardShips.AddRange(CreateShips<Destroyer>(DestroyersCount));
        boardShips.AddRange(CreateShips<Submarine>(SubmarinesCount));
        boardShips.AddRange(CreateShips<Cruiser>(CruisersCount));
        boardShips.AddRange(CreateShips<Battleship>(BattleshipsCount));
        boardShips.AddRange(CreateShips<Carrier>(CarriersCount));

        return boardShips;
    }

    private static IEnumerable<TShip> CreateShips<TShip>(int shipsCount) where TShip : Ship, new() => 
        Enumerable.Range(0, shipsCount).Select(_ => new TShip());
}