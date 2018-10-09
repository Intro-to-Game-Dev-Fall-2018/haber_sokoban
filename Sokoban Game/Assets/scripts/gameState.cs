using UnityEngine;

public class GameState : ScriptableObject
{
    public int moves;
    public int totalMoves;
    public string levelName;

    public void reset()
    {
        moves = 0;
    }
}