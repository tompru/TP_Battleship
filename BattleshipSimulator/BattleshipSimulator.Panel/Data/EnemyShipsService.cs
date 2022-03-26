using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Panel.Data;

public class EnemyShipsService
{
    public int GetTotalSize(BoardShips? enemyShips) =>
        enemyShips?.Values.Sum(x => x.Size.Value) ?? default;
    public int GetTotalDamageTaken(BoardShips? enemyShips) =>
        enemyShips?.Values.Sum(x => x.DamageTaken.Value) ?? default;

    public IReadOnlyList<EnemyShipSummaryModel> GetSummary(BoardShips? enemyShips)
    {
        var result = new List<EnemyShipSummaryModel>();
        if (enemyShips is null)
        {
            return result;
        }

        var groupedShips = enemyShips.Values
            .GroupBy(x => x.GetType())
            .ToDictionary(x => x.Key, x => x.ToList());
        foreach (var (shipType, ships) in groupedShips)
        {
            var shipsLeft = ships.Count - ships.Count(x => x.IsSunk);
            var shipSize = ships.FirstOrDefault()?.Size.Value ?? default;
            result.Add(new EnemyShipSummaryModel(shipType.Name, shipsLeft, ships.Count, shipSize));
        }

        return result;
    }
}