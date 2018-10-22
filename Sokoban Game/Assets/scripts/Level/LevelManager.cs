using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LevelUpdateEvent : UnityEvent<LevelData> {}

public class LevelManager : MonoBehaviour
{
    [Header("Assets")] 
    [SerializeField] private Levels _levelsAsset;
    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _goal;

    public static LevelUpdateEvent onLevelUpdate;
    private LevelData _levelData;
    
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

        for (var i = 0; i < lines.Length; i++)
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
        
        GameManager.Instance.State.boxCount = numBoxes;
        GameManager.Instance.State.goalCount = numGoals;
        GameManager.Instance.State.moves = 0;
        GameManager.Instance.State.boxesOnGoals = 0;
        
        _levelData.init(lines);
        onLevelUpdate.Invoke(_levelData);
        
        if (numBoxes!=numGoals) nextLevel();
    }

    private void Awake()
    {
        if (onLevelUpdate==null) onLevelUpdate = new LevelUpdateEvent();
        _levelData = ScriptableObject.CreateInstance<LevelData>();
        
        string[] split = {"\n\n"};
        currentLevel = -1;
        _levels = _levelsAsset.getLevelSet().text.Split(split, StringSplitOptions.RemoveEmptyEntries);
    }

    private void Start()
    {
        nextLevel();
    }
}