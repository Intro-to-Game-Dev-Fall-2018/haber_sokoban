using UnityEngine;

[CreateAssetMenu(menuName = "Level Set Container")]
public class Levels : ScriptableObject
{
	[Header("Level Sets")]
	[SerializeField] private TextAsset[] _levelSets;
	private int _cur;
	
	public TextAsset nextLevelSet()
	{
		_cur = (_cur + 1) % _levelSets.Length;
		return getLevelSet();
	}
	
	public TextAsset getLevelSet()
	{
		return _levelSets[_cur];
	}

}
