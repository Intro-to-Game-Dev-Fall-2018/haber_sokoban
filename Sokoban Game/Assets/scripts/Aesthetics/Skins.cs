using System;
using UnityEngine;
using UnityEngine.Events;

public class GameSkinChange : UnityEvent<GameSkin> {}

[Serializable]
public struct GameSkin
{
	public string SkinName;
	public Color Background;
	public Color TextColor;

	public WorldSprites WorldSprites;
	public PlayerSprites PlayerSprites;
}

[Serializable]
public struct WorldSprites
{
	public Sprite Box;
	public Sprite BoxGoal;
	public Sprite Goal;
	public Sprite Wall;	
}

[Serializable]
public struct PlayerSprites
{
	public Sprite[] WalkSide;
	public Sprite[] PushSide;
	public Sprite[] WalkTop;
	public Sprite[] PushTop;
}

[CreateAssetMenu(fileName = "Skins", menuName = "Skins/Skins")]
public class Skins : ScriptableObject
{
	public GameSkinChange onChangeSkin;
	
	[Header("Skins")]
	[SerializeField] private GameSkin[] _skins;

	private int current;

	private void OnEnable()
	{
		if (onChangeSkin==null) onChangeSkin = new GameSkinChange();
	}

	public GameSkin CurrentSkin()
	{
		return _skins[current];
	}

	public GameSkin NextSkin()
	{
		current = (current + 1) % _skins.Length;
		onChangeSkin.Invoke(CurrentSkin());
		return CurrentSkin();
	}

}
