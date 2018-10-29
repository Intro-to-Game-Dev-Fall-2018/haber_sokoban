using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Assets")] 
    [SerializeField] private Levels _levelsAsset;
    [SerializeField] private MapLoader _loader;

    public static LevelUpdateEvent onLevelUpdate;
    
    private string[] _levels;
    private Set _set;

    public void ResetLevel()
    {
        GameManager.Instance.State.ResetLevel();
        LoadLevel(_set.Progress);
    }

    public void SkipLevel()
    {
        _set.Progress++;
        LoadLevel(_set.Progress);
    }
    
    public void NextLevel()
    {
        _set.FinishLevel(GameManager.Instance.State.moves);
        LoadLevel(_set.Progress);
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
    }

    private void Start()
    {
        LoadLevel(_set.Progress);
    }
}
