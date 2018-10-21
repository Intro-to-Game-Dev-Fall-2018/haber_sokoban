﻿using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Assets")] 
    [SerializeField] private Levels _levelsAsset;
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _goal;

    private string[] _levels;
    private int currentLevel;

    public void resetLevel()
    {
        GameManager.Instance.State.totalMoves -= GameManager.Instance.State.moves;   
        loadLevel(currentLevel);
    }
    
    public void nextLevel()
    {
        if (currentLevel++ >= _levels.Length) return;
        currentLevel = currentLevel % _levels.Length;
        loadLevel(currentLevel);
    }
    
    private void loadLevel(int level)
    {
        foreach (Transform child in transform) 
            Destroy(child.gameObject);
        
        var lines = _levels[level].Split('\n');
        var numBoxes = 0;
        var numGoals = 0;
        var width = 0;
        var name = "level";
        
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(";"))
            {
                name = lines[i].Replace("; ","");
                continue;
            }
            
            if (lines[i].Length > width) width = lines[i].Length;
            
            for (var j = 0; j < lines[i].Length; j++)
            {
                var pos = new Vector3(j,-i,0f);
                
                switch (lines[i][j])
                {
                    case '#':
                        Instantiate(_wall,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '@':
                        Instantiate(_player,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '$':
                        Instantiate(_box,pos,Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        break;
                    case '.':
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '+': 
                        Instantiate(_player,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '*':
                        Instantiate(_box,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        numGoals++;
                        break;
                    // ReSharper disable once RedundantEmptySwitchSection
                    default:
                        break;
                }
            }
        }

        if (numBoxes!=numGoals) print("boxes does not equal goals");
        
        GameManager.Instance.State.boxCount = numBoxes;
        GameManager.Instance.State.goalCount = numGoals;
        GameManager.Instance.State.levelHeight = lines.Length - 1;
        GameManager.Instance.State.levelWidth = width - 1;
        GameManager.Instance.State.levelName = name;
        GameManager.Instance.State.moves = 0;
        GameManager.Instance.State.boxesOnGoals = 0;
    }

    private void Awake()
    {
        string[] split = {"\n\n"};
        currentLevel = -1;
        _levels = _levelsAsset.getLevelSet().text.Split(split, StringSplitOptions.RemoveEmptyEntries);
        nextLevel();
    }
    
}