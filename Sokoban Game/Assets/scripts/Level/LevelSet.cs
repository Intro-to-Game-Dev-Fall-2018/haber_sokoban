using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Set",menuName = "Levels/Level Set")]
public class LevelSet : ScriptableObject
{

    [SerializeField] private TextAsset _levelText;
    private string setName; 
    private int size;
    private int[] score;
    private string[] levels;
    private int current;

    private void Awake()
    {
        if (setName == _levelText.name) return;
        string[] split = {"\n\n"};
        levels = _levelText.text.Split(split, StringSplitOptions.RemoveEmptyEntries);
        setName = _levelText.name;
        size = levels.Length;
        score = new int[size];
        current = 0;
    }

    public string getCurrentLeve()
    {
        return levels[current];
    }

    public string completeLevel(int numMoves)
    {
        if (score[current] == 0 || numMoves < score[current])
            score[current] = numMoves;
        
        return nextLevel();
    }

    public string nextLevel()
    {
        current = (current + 1) % size;
        return levels[current];
    }
    
}
