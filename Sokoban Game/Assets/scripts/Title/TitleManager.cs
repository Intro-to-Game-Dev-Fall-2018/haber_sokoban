using UnityEngine;

public class TitleManager : MonoBehaviour
{
	private void Update () {
		if (Input.GetButton("Submit"))
			StartCoroutine(Loader.LoadMenuFromTitle());
	}
}
