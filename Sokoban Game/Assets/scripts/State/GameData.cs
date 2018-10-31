using UnityEngine;

public class GameData : MonoBehaviour
{
	public static Skins Skins;
	public static Levels Levels;
	public static GameSettings Settings;
	
	[SerializeField] private Skins _skins;
	[SerializeField] private Levels _levels;
	[SerializeField] private GameSettings _settings;

	private void Awake()
	{
		if (Skins == null) Skins = _skins;
		if (Levels == null) Levels = _levels;
		if (Settings == null) Settings = _settings;
	}
}
