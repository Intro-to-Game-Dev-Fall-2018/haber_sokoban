using System;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class LevelUpdateEvent : UnityEvent<LevelData> {}

public class LevelData : ScriptableObject 
{
    public string LevelName;
    
    public float width;
    public float height;

    public void init(string[] input)
    {
        width = 0;
        height = 0;
        
        foreach (var line in input)
            if (line.StartsWith(";"))
                LevelName = line.Replace("; ","");
            else
            {
                height++;
                if (line.Length > width)
                    width = line.Length;
            }
    }
}
