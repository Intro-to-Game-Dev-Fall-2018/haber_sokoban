using UnityEngine;

public class MapLoader : MonoBehaviour
{

    public Box Box;
    public Goal Goal;
    public Wall Wall;
    public PlayerController Player;
    
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
                        Instantiate(Wall, pos, Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '@':
                        Instantiate(Player, pos, Quaternion.identity).transform.SetParent(transform);
                        break;
                    case '$':
                        Instantiate(Box, pos, Quaternion.identity).transform.SetParent(transform);
                        numBoxes++;
                        break;
                    case '.':
                        Instantiate(Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '+':
                        Instantiate(Player, pos, Quaternion.identity).transform.SetParent(transform);
                        Instantiate(Goal, pos, Quaternion.identity).transform.SetParent(transform);
                        numGoals++;
                        break;
                    case '*':
                        Instantiate(Box, pos, Quaternion.identity).transform.SetParent(transform);
                        Instantiate(Goal, pos, Quaternion.identity).transform.SetParent(transform);
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