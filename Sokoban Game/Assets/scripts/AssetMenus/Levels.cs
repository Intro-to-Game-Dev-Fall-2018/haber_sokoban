using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Levels")]
public class Levels : ScriptableObject
{
	[Header("Level Sets")]
	[SerializeField] private TextAsset[] levelSets;

	private int _cur;
	
	public string nextLevelSet()
	{
		_cur = (_cur + 1) % levelSets.Length;
		return levelSets[_cur].name;
	}
	
	public TextAsset getLevelSet()
	{
		return levelSets[_cur];
	}

}
