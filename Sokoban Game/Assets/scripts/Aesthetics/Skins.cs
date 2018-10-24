using System;
using UnityEngine;
using UnityEngine.Events;

public class OnChangeSkin : UnityEvent<Skin> {}

[Serializable]
public struct Skin
{
	public string SkinName;
	public GameObject Box;
	public GameObject Goal;
	public GameObject Player;
	public GameObject Wall;
	public Color Background;
	public Color TextColor;
	public Color ButtonColor;
}

[CreateAssetMenu(fileName = "Skin Set", menuName = "Skins/Skin Set")]
public class Skins : ScriptableObject
{
	public OnChangeSkin onChangeSkin;
	
	[SerializeField] private Skin[] _skins;
	private int current;

	private void OnEnable()
	{
		if (onChangeSkin==null) onChangeSkin = new OnChangeSkin();
	}

	public Skin CurrentSkin()
	{
		return _skins[current];
	}

	public Skin NextSkin()
	{
		current = (current + 1) % _skins.Length;
		onChangeSkin.Invoke(CurrentSkin());
		return CurrentSkin();
	}

}
