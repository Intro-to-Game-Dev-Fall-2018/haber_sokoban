using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour {

	private void Start () {
		GetComponent<Button>().onClick.AddListener(() => { StartCoroutine(Loader.LoadGame());});
	}
	
}
