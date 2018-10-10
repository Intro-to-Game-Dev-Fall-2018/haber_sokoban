using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Inputs")] 
    [SerializeField] private TextAsset _levelSet;

    [Header("Assets")] 
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _box;
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
        var numBoxes = 0;
        var numGoals = 0;
        var width = 0;
        var height = 0;
        var name = "level";
        
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length > width) width = lines[i].Length;
            
            if (lines[i].StartsWith(";"))
            {
                name = lines[i].Replace("; ","");
                continue;
            }
            
            for (var j = 0; j < lines[i].Length; j++)
            {
                height++;
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
                        Instantiate(_box,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        break;
                    case '.':
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '+': 
                        Instantiate(_player,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '*':
                        Instantiate(_box,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_goal,pos,Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        numGoals++;
                        break;
                    default:
                        Instantiate(_floor,pos,Quaternion.identity).transform.SetParent(transform);
                        break;
                }
            }
        }

        if (numBoxes!=numGoals) print("boxes does not equal goals");
        
        GameManager.Instance.State.boxCount = numBoxes;
        GameManager.Instance.State.goalCount = numGoals;
        GameManager.Instance.State.levelHeight = height;
        GameManager.Instance.State.levelWidth = width;
        GameManager.Instance.State.levelName = name;

    }

    private void Start()
    {
        string[] split = {"\n\n"};
        currentLevel = -1;
        _levels = _levelSet.text.Split(split, StringSplitOptions.RemoveEmptyEntries);
        nextLevel();
    }
    
}