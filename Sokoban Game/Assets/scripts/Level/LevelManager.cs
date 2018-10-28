using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Assets")] 
    [SerializeField] private Levels _levelsAsset;
    [SerializeField] private MapLoader _loader;

    public static LevelUpdateEvent onLevelUpdate;
    
    private string[] _levels;
    private int currentLevel;
    private Set _set;

    public void ResetLevel()
    {
        GameManager.Instance.State.ResetLevel();
        LoadLevel(currentLevel);
    }
    
    public void NextLevel()
    {
        if (currentLevel++ >= _levels.Length) return;
        currentLevel = currentLevel % _levels.Length;
        LoadLevel(currentLevel);
        _set.Progress = currentLevel;
    }
    
    private void LoadLevel(int level)
    {
        GameManager.Instance.State.NewLevel();
        var lines = _levels[level].Split('\n');
        var data = _loader.LoadLevel(lines);
        onLevelUpdate.Invoke(data);
    }

    private void Awake()
    {
        if (onLevelUpdate==null) onLevelUpdate = new LevelUpdateEvent();
        
        _set = _levelsAsset.Set;
        _levels = _set.GetLevels();
        currentLevel = _set.Progress;
    }

    private void Start()
    {
        ResetLevel();
    }
}
