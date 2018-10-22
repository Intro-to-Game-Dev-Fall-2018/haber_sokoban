using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct AssetSet
{
	public string SkinName;
	public GameObject Box;
	public GameObject Goal;
	public GameObject Player;
	public GameObject Wall;
	public Color background;
}

[CreateAssetMenu(fileName = "Skin Set", menuName = "Skins/Skin Set")]
public class Skins : ScriptableObject
{
	[SerializeField] private AssetSet[] _skins;
	private int current;

	public AssetSet CurrentSkin()
	{
		return _skins[current];
	}

	public AssetSet NextSkin()
	{
		current = (current + 1) % _skins.Length;
		return CurrentSkin();
	}

}
