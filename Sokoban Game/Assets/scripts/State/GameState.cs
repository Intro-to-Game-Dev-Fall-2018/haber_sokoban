﻿
public class GameState 
{
    
    public int moves;
    public int totalMoves;
    public int bestMoves;

    public int boxCount;
    public int goalCount;
    public int boxesOnGoals;

    public void ResetLevel()
    {
        totalMoves -= moves;
        moves = 0;
    }

    public void NewLevel()
    {
        moves = 0;
    }

    public void Undo()
    {
        moves--;
        totalMoves--;
    }

    public void Move()
    {
        moves++;
        totalMoves++;
    }
    
}