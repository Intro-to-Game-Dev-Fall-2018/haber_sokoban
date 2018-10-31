using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
	[SerializeField] private Transform _title;
	[SerializeField] private Transform _destination;
	[SerializeField] private Text _press2Start;

	private void Start()
	{
		StartCoroutine(MoveTitle(_destination.position));
	}

	private void Update () {
		if (Input.GetButton("Submit"))
			StartCoroutine(Loader.LoadMenuFromTitle());
	}

	private IEnumerator MoveTitle(Vector3 dest)
	{
		var moveDistance = _title.position.y - dest.y;
		moveDistance /= 128;
		
		while (true)
		{
			var pos = _title.position;

			_press2Start.enabled = false;
			var newPos = Vector3.MoveTowards(pos, dest, moveDistance);
			
			_title.SetPositionAndRotation(newPos,Quaternion.identity);
			yield return new WaitForEndOfFrame();
			
			if ((dest-pos).sqrMagnitude < .1f) break;
		}
		yield return new WaitForSecondsRealtime(.5f);
		StartCoroutine(AnimateP2S());
	}

	private IEnumerator AnimateP2S()
	{
		while (true)
		{
			_press2Start.enabled = !_press2Start.enabled;
			yield return new WaitForSecondsRealtime(.8f);
		}
	}
}
