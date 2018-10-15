using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance;
	[HideInInspector] public GameState State;
	
	public GameSettings Settings;
	[SerializeField] private LevelManager _levelManager;

	private bool _active;
	
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance!= this)
			Destroy(gameObject);

		_active = true;
		State = ScriptableObject.CreateInstance<GameState>();
	}

	private void Update()
	{
		if (!_active) return;
		
		if (State.boxesOnGoals == State.goalCount) 
			StartCoroutine(nextLevel());
	}

	private IEnumerator nextLevel()
	{
		_active = false;
		yield return new WaitForSeconds(Settings.waitAfterMap);
		_levelManager.nextLevel();
		_active = true;
	}

}
