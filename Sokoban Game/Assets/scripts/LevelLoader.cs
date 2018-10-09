using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Inputs")] 
    [SerializeField] private TextAsset _levelSet;

    [Header("Assets")] 
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _package;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _goal;
    [SerializeField] private GameObject _floor;

    private string[] _levels;
    private int currentLevel;

    public void nextLevel()
    {
        if (currentLevel >= _levels.Length) return;

        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        
        loadLevel();
    }
    
    private void loadLevel()
    {
        var lines = _levels[currentLevel++].Split('\n');
        
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(";")) continue;
            for (var j = 0; j < lines[i].Length; j++)
            {
                var pos = new Vector3(j,-i,0f);
                
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (lines[i][j])
                {
                    case '#':
                        Instantiate(_wall,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '@':
                        Instantiate(_player,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '$':
                        Instantiate(_package,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '.':
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '+': 
                        Instantiate(_player,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '*':
                        Instantiate(_package,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                }
                Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
            }
        }

    }

    private void Start()
    {
        string[] split = {"\n\n"};
        currentLevel = 0;
        _levels = _levelSet.text.Split(split, StringSplitOptions.RemoveEmptyEntries);
        nextLevel();
    }
    
}