using UnityEngine;

public class MapLoader : MonoBehaviour
{

    [SerializeField] 
    private PrefabLoader _prefabLoader;
    
    public LevelData LoadLevel(string[] lines)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        int numBoxes = 0;
        int numGoals = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(";")) continue;
            for (int j = 0; j < lines[i].Length; j++)
            {
                Vector3 pos = new Vector3(j, -i, 0f);
                switch (lines[i][j])
                {
                    case '#':
                        Instantiate(_prefabLoader.Wall, pos, Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '@':
                        Instantiate(_prefabLoader.Player, pos, Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '$':
                        Instantiate(_prefabLoader.Box, pos, Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        break;
                    case '.':
                        Instantiate(_prefabLoader.Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '+':
                        Instantiate(_prefabLoader.Player, pos, Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_prefabLoader.Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '*':
                        Instantiate(_prefabLoader.Box, pos, Quaternion.identity).transform.SetParent(transform);
                        Instantiate(_prefabLoader.Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        numGoals++;
                        break;
                    // ReSharper disable once RedundantEmptySwitchSection
                    default:
                        break;
                }
            }
        }

        GameManager.Instance.State.boxCount = numBoxes;
        GameManager.Instance.State.goalCount = numGoals;
        GameManager.Instance.State.boxesOnGoals = 0;

        LevelData data = new LevelData(lines);
        return data;
    }
}