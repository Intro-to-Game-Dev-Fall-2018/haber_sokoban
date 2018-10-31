using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelUpdateEvent onLevelUpdate;
    
    [SerializeField] private MapLoader _loader;

    private string[] _levelText;
    private Set _set;
    
    private void Awake()
    {
        if (onLevelUpdate==null) onLevelUpdate = new LevelUpdateEvent();
        _set = GameData.Levels.Set;
        _levelText = _set.GetLevels();
    }

    private void Start()
    {
        LoadLevel(_set.Progress);
    }

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
        var lines = _levelText[level].Split('\n');
        var data = _loader.LoadLevel(lines);
        onLevelUpdate.Invoke(data);
    }


}
