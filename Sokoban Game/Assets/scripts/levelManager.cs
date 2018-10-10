using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
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

    public void resetLevel()
    {
        loadLevel(currentLevel);
    }
    
    public void nextLevel()
    {
        if (currentLevel++ >= _levels.Length) return;
        loadLevel(currentLevel);
    }
    
    private void loadLevel(int level)
    {
        foreach (Transform child in transform) 
            Destroy(child.gameObject);
        
        var lines = _levels[level].Split('\n');
        var numPackages = 0;
        
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(";"))
            {
                GameManager.Instance.State.levelName = lines[i].Replace("; ","");
                continue;
            }
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
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '$':
                        Instantiate(_package,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        numPackages++;
                        break;
                    case '.':
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '+': 
                        Instantiate(_player,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '*':
                        Instantiate(_package,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                    default:
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                }
               
            }
        }

    }

    private void Start()
    {
        string[] split = {"\n\n"};
        currentLevel = -1;
        _levels = _levelSet.text.Split(split, StringSplitOptions.RemoveEmptyEntries);
        nextLevel();
    }
    
}