namespace BattleshipSimulator.Model.Ships;

public class BoardShips
{
    private const int DestroyersCount = 5;
    private const int SubmarinesCount = 4;
    private const int CruisersCount = 3;
    private const int BattleshipsCount = 2;
    private const int CarriersCount = 1;

    public IReadOnlyList<Ship> Values { get; } = InitializeBoardShips();

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

    private static IEnumerable<TShip> CreateShips<TShip>(int shipsCount) where TShip : Ship, new()
    {
        return Enumerable.Range(0, shipsCount).Select(_ => new TShip());
    }
}