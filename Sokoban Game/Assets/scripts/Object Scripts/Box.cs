using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

	private SpriteRenderer _renderer;
	[SerializeField] private Sprite _sprite;
	[SerializeField] private Sprite _onGoal;

	private void Start()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Goal"))
			_renderer.sprite = _onGoal;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Goal"))
			_renderer.sprite = _sprite;
	}
}
