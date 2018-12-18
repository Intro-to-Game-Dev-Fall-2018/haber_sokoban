using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
	private SpriteRenderer _renderer;

	private void Start()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_renderer.sprite = GameData.i.Skins2.CurrentSkin().WorldSprites.Box;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Goal"))
			StartCoroutine(DelayChange());
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Goal"))
			_renderer.sprite = GameData.i.Skins2.CurrentSkin().WorldSprites.Box;
	}
	
	private IEnumerator DelayChange()
	{
		yield return new WaitForSeconds(GameData.i.Settings.moveTime+.05f);
		_renderer.sprite = GameData.i.Skins2.CurrentSkin().WorldSprites.BoxGoal;
	}
}
