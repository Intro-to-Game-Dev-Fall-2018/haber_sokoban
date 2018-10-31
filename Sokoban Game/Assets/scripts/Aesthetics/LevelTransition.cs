using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{

	[SerializeField] private Text _text;
	[SerializeField] private Image _image;

	private float duration;
	
	private void Start ()
	{
		duration = GameData.Settings.transitionDuration;
		LevelManager.onLevelUpdate.AddListener(Transition);
	}
	
	private void Transition(LevelData data)
	{
		StopCoroutine(AnimateTransition());
		_text.text = data.LevelName;
		StartCoroutine(AnimateTransition());
	}

	private IEnumerator AnimateTransition()
	{
		var imageColor = _image.color;
		var textColor = _text.color;
		var alpha = 1f;
		
		textColor.a = alpha;
		imageColor.a = alpha;
		_image.color = imageColor;
		_text.color = textColor;
		
		yield return new WaitForSecondsRealtime(GameData.Settings.delayBeforeTransition);

		for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
		{
			alpha =  Mathf.Lerp(alpha, 0, t);
			imageColor.a = alpha;
			textColor.a = alpha;
			_image.color = imageColor;
			_text.color = textColor;
			yield return null;
			if (alpha < float.Epsilon) yield break;
		}
	}
	
}
