using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance;
	
	[HideInInspector] public GameState State;
	
	public GameSettings Settings;
	public Levels Levels;
	
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

	public void loadMenu()
	{
		StartCoroutine(MenuLoader());
	}

	private IEnumerator MenuLoader()
	{
		var op = SceneManager.LoadSceneAsync("menu", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("game");
		yield return op;
	}

}
