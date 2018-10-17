using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public void startGame()
	{
		StartCoroutine(LoadGame());
	}
	
	private IEnumerator LoadGame()
	{
		var op = SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("menu");
		yield return op;
	}
}

