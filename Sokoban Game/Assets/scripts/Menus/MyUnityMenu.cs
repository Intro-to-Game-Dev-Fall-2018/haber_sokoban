using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyUnityMenu : ScriptableObject {

    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
