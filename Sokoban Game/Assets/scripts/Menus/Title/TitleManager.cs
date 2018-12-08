using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
	[SerializeField] private Transform _title;
	[SerializeField] private Transform _destination;
	[SerializeField] private Text _press2Start;

	private bool _canStart;
	
	private void Start()
	{
		_press2Start.enabled = false;

		_title.transform.DOMove(_destination.position, 2f)
			.SetDelay(1f)
			.SetEase(Ease.InOutBounce)
			.OnComplete(()=>StartCoroutine(AnimateP2S()));
	}

	private void Update () {
		if (!_canStart) return;
		
		if (Input.anyKey)
		_press2Start.transform.DOShakePosition(.5f)
			.OnComplete(()=>StartCoroutine(Loader.LoadMenuFromTitle()));
	}

	private IEnumerator AnimateP2S()
	{
		yield return new WaitForSeconds(.5f);
		_canStart = true;
		
		while (true)
		{
			_press2Start.enabled = !_press2Start.enabled;
			yield return new WaitForSecondsRealtime(.8f);
		}
	}
}
