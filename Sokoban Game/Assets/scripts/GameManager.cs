using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance = null;
	public static GameState State;
	
	[SerializeField] private LevelManager _level;
	
	
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance!= this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		State = ScriptableObject.CreateInstance<GameState>();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
