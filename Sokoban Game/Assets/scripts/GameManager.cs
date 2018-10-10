using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance;
	[HideInInspector] public GameState State;
	public GameSettings Settings;
	
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance!= this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		State = ScriptableObject.CreateInstance<GameState>();
	}

}
