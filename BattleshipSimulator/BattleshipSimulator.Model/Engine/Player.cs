using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Results;
using BattleshipSimulator.Model.Ships;

namespace BattleshipSimulator.Model.Engine;

public class Player
{
    public Player(IShipArranger arranger)
    {
        PrimaryBoard = new PrimaryBoard(arranger);
        TrackingBoard = new TrackingBoard();
    }

    public PrimaryBoard PrimaryBoard { get; }
    public TrackingBoard TrackingBoard { get; }

    public OperationResult SetupEnemyShips(BoardShips enemyShips) => TrackingBoard.SetupEnemyShips(enemyShips);
}