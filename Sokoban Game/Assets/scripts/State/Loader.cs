using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
	private static bool isLoading;
	
	private void Start ()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		SceneManager.LoadSceneAsync("title", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("audio", LoadSceneMode.Additive);
	}

	public static IEnumerator LoadMenuFromTitle()
	{
		if (isLoading) yield break;
		isLoading = true;
		AsyncOperation operation = SceneManager.LoadSceneAsync("menu", LoadSceneMode.Additive);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
		SceneManager.UnloadSceneAsync("title");
		isLoading = false;
	}
	
	public static IEnumerator LoadGame()
	{
		if (isLoading) yield break;
		isLoading = true;
		AsyncOperation operation = SceneManager.LoadSceneAsync("game", LoadSceneMode.Additive);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
		SceneManager.UnloadSceneAsync("menu");
		isLoading = false;
	}
	
	public static IEnumerator LoadMenu()
	{
		if (isLoading) yield break;
		isLoading = true;
		AsyncOperation operation = SceneManager.LoadSceneAsync("menu", LoadSceneMode.Additive);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
		SceneManager.UnloadSceneAsync("game");
		isLoading = false;
	}
	
}
