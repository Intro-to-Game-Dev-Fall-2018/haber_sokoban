using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings",menuName = "Settings/Game Settings")]
public class GameSettings : ScriptableObject
{
	[Header("Time")] 
	public float moveTime = .5f;
	public float waitAfterMap = 2f;
	public float undoDelay = .5f;
}
