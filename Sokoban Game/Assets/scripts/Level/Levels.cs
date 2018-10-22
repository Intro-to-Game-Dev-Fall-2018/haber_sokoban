using UnityEngine;

[CreateAssetMenu(fileName = "Level Set Container",menuName = "Levels/Level Set Container")]
public class Levels : ScriptableObject
{
	[Header("Level Sets")]
	[SerializeField] private TextAsset[] _levelSets;
	private int current;
	
	public TextAsset nextLevelSet()
	{
		current = (current + 1) % _levelSets.Length;
		return getLevelSet();
	}
	
	public TextAsset getLevelSet()
	{
		return _levelSets[current];
	}

}
