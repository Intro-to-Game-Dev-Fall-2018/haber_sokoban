#if (UNITY_EDITOR) 

using UnityEditor;
using UnityEngine;

public class MyUnityMenu : ScriptableObject {

    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

#endif
