using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Model.Boards;
using BattleshipSimulator.Model.Results;

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
    public bool HasLost => PrimaryBoard.Ships.Values.All(x => x.IsSunk);

    public OperationResult PlayRound(PrimaryBoard enemyPrimaryBoard)
    {
        var getCoordinatesResult = TrackingBoard.GetCoordinatesToAttack();
        if (getCoordinatesResult.Failure)
        {
            return getCoordinatesResult;
        }

        var markShotResult = enemyPrimaryBoard.MarkHit(getCoordinatesResult.Payload!);
        if (markShotResult.Failure)
        {
            return markShotResult;
        }

        return TrackingBoard.MarkAttackedField(getCoordinatesResult.Payload!, markShotResult.Payload!);
    }
}