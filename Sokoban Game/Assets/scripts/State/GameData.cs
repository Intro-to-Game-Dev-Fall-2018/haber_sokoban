using UnityEngine;

public class GameData : MonoBehaviour
{

	public static GameData i;
	
	public Skins Skins;
	public Levels Levels;
	public GameSettings Settings;

	private void Awake()
	{
		if (i == null) i = this;
		else Destroy(gameObject);
	}
}
