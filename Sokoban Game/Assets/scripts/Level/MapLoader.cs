using UnityEngine;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private Skins _skins;

    public LevelData LoadLevel(string[] lines)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        var assets = _skins.CurrentSkin();
        var numBoxes = 0;
        var numGoals = 0;
        var data = ScriptableObject.CreateInstance(typeof(LevelData)) as LevelData;

        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith(";")) continue;
            for (var j = 0; j < lines[i].Length; j++)
            {
                var pos = new Vector3(j, -i, 0f);
                switch (lines[i][j])
                {
                    case '#':
                        Instantiate(assets.Wall, pos, Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '@':
                        Instantiate(assets.Player, pos, Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '$':
                        Instantiate(assets.Box, pos, Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        break;
                    case '.':
                        Instantiate(assets.Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '+':
                        Instantiate(assets.Player, pos, Quaternion.identity).transform.SetParent(transform);
                        Instantiate(assets.Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '*':
                        Instantiate(assets.Box, pos, Quaternion.identity).transform.SetParent(transform);
                        Instantiate(assets.Goal, pos, Quaternion.identity).transform.SetParent(transform);
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
        GameManager.Instance.State.moves = 0;
        GameManager.Instance.State.boxesOnGoals = 0;

        data.init(lines);
        return data;
    }
}