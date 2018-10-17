using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
	[Header("Time")] 
	public float moveTime = .5f;
	public float waitAfterMap = 2f;

}
