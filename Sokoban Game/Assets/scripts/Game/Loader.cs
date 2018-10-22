using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	private void Start ()
	{
		SceneManager.LoadSceneAsync("menu", LoadSceneMode.Additive);
		SceneManager.LoadSceneAsync("audio", LoadSceneMode.Additive);
	}
	
}
