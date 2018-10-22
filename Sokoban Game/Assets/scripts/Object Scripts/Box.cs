using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

	private SpriteRenderer _renderer;
	private Sprite _sprite;
	[SerializeField] private Sprite _onGoal;

	private void Start()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_sprite = _renderer.sprite;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Goal"))
			StartCoroutine(DelayChange());
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Goal"))
			_renderer.sprite = _sprite;
	}
	
	private IEnumerator DelayChange()
	{
		yield return new WaitForSeconds(GameManager.Instance.Settings.moveTime+.05f);
		_renderer.sprite = _onGoal;
	}
}
