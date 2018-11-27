using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{

	[SerializeField] private Text _text;
	[SerializeField] private Image _image;

	private float duration;
	private IEnumerator current;
	
	private void Start ()
	{
		duration = GameData.Settings.transitionDuration;
		LevelManager.onLevelUpdate.AddListener(Transition);
	}
	
	private void Transition(LevelData data)
	{
		StopAllCoroutines();
		_text.text = data.LevelName;
		StartCoroutine(AnimateTransition());
	}

	private IEnumerator AnimateTransition()
	{
		Color imageColor = _image.color;
		Color textColor = _text.color;
		float alpha = 1f;
		
		textColor.a = alpha;
		imageColor.a = alpha;
		_image.color = imageColor;
		_text.color = textColor;
		
		yield return new WaitForSecondsRealtime(GameData.Settings.delayBeforeTransition);

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
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
