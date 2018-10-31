using System;
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
		_text.text = data.LevelName;
		StartCoroutine(AnimateTransition());
	}

	private IEnumerator AnimateTransition()
	{
		var imageColor = _image.color;
		var textColor = _text.color;
		textColor.a = 1;
		imageColor.a = 1;
		_image.color = imageColor;
		_text.color = textColor;
		yield return new WaitForSecondsRealtime(GameData.Settings.delayBeforeTransition);

		for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
		{
			imageColor.a = Mathf.Lerp(imageColor.a, 0, t);
			textColor.a = Mathf.Lerp(textColor.a, 0, t);
			_image.color = imageColor;
			_text.color = textColor;
			yield return null;
		}
	}
	
}
