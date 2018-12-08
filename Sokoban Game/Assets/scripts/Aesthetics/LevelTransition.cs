using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour
{

	[SerializeField] private Text _text;
	[SerializeField] private Image _image;

	private void Start ()
	{
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
		
		textColor.a = 1f;
		imageColor.a = 1f;
		_image.color = imageColor;
		_text.color = textColor;
		
		yield return new WaitForSecondsRealtime(GameData.Settings.delayBeforeTransition);

		_image.DOFade(0, GameData.Settings.transitionDuration).SetEase(Ease.Linear);
		_text.DOFade(0, GameData.Settings.transitionDuration).SetEase(Ease.Linear);
	}
	
}
