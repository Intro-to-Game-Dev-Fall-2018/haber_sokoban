using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

	[SerializeField] private Text _levelSet;
	[SerializeField] private Levels _levels;

	private void Start()
	{
		_levelSet.text = _levels.nextLevelSet();
	}

	public void startGame()
	{
		StartCoroutine(LoadGame());
	}

	public void cycleLevelSets()
	{
		_levelSet.text = _levels.nextLevelSet();
	}
	
	private IEnumerator LoadGame()
	{
		var op = SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("menu");
		yield return op;
	}
	
}

