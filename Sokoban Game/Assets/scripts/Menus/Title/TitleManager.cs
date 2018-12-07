using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
	[SerializeField] private Transform _title;
	[SerializeField] private Transform _destination;
	[SerializeField] private Text _press2Start;

	private void Start()
	{
		_press2Start.enabled = false;

		_title.transform.DOMove(_destination.position, 1.5f)
			.OnComplete(()=>StartCoroutine(AnimateP2S()));
	}

	private void Update () {
		if (Input.GetButton("Submit"))
		_press2Start.transform.DOScale(new Vector3(2f, .1f), .1f)
			.OnComplete(()=>StartCoroutine(Loader.LoadMenuFromTitle()));
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

//	private IEnumerator MoveTitle(Vector3 dest)
//	{
//		float moveDistance = _title.position.y - dest.y;
//		moveDistance /= 128;
//		
//		while (true)
//		{
//			Vector3 pos = _title.position;
//
//			_press2Start.enabled = false;
//			Vector3 newPos = Vector3.MoveTowards(pos, dest, moveDistance);
//			
//			_title.SetPositionAndRotation(newPos,Quaternion.identity);
//			yield return new WaitForEndOfFrame();
//			
//			if ((dest-pos).sqrMagnitude < .1f) break;
//		}
//		yield return new WaitForSecondsRealtime(.5f);
//		StartCoroutine(AnimateP2S());
//	}

