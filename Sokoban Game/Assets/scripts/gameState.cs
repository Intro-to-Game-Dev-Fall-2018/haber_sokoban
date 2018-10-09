using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : ScriptableObject
{
    public int moves;


    public void reset()
    {
        moves = 0;
    }
}