using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LevelUpdateEvent : UnityEvent<LevelData> {}

public class LevelData  
{
    public readonly string LevelName;
    
    public readonly float width;
    public readonly float height;

    public LevelData(string[] input)
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
