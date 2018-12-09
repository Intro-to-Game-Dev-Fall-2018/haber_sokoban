using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	
	public GameState State;
	
	[SerializeField] private LevelManager _levelManager;

	private bool _active;
	
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance!= this)
			Destroy(gameObject);

		_active = true;
		State = new GameState();
	}

	private void Update()
	{
		if (!_active) return;
		
		if (State.boxesOnGoals == State.goalCount) 
			StartCoroutine(PassLevel());
		else if (Input.GetButton("Reset")) 
			_levelManager.ResetLevel();
	}

	//public functions
	public void Undo()
	{
		if (State.moves == 0) return;
		StartCoroutine(UndoRoutine());
	}


	//Coroutines
	private IEnumerator PassLevel()
	{
		_active = false;
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime(GameData.Settings.waitAfterMap);
		Time.timeScale = 1;
		_levelManager.NextLevel();
		_active = true;
	}
	
	private IEnumerator UndoRoutine()
	{
		yield return new WaitForEndOfFrame();
		if (!_active) yield break;
		_active = false;
		Instance.State.Undo();
		foreach (var obj in FindObjectsOfType<MovingObject>())
			obj.Undo(Instance.State.moves);
		yield return new WaitForSecondsRealtime(GameData.Settings.undoDelay);
		_active = true;
	}

}
