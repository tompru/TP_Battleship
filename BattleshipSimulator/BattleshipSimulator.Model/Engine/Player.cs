using BattleshipSimulator.Model.Boards;

namespace BattleshipSimulator.Model.Engine;

public class Player
{
    public Player()
    {
        PrimaryBoard = new PrimaryBoard();
        TrackingBoard = new TrackingBoard(PrimaryBoard.Ships);
    }

    public PrimaryBoard PrimaryBoard { get; }
    public TrackingBoard TrackingBoard { get; }
}