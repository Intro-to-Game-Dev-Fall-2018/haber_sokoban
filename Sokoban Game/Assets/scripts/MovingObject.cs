﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=fURWEzpNPL8
public class MovingObject : MonoBehaviour
{

	[Header("Wall Filter")]
	[SerializeField] private LayerMask _wallLayer;
	[SerializeField] private LayerMask _boxLayer;
	
	private Rigidbody2D _rb2d;
	private float inverseMoveTime;
	
	private void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / .5f;
	}
	
	public bool move(Vector2 direction)
	{
		var newPosition = _rb2d.position + direction;
		
		if (wallAt(newPosition)) return false;
		if (boxAt(newPosition))
			if (!pushBox(newPosition, direction))
				return false;
			
		_rb2d.MovePosition(_rb2d.position + direction);
		return true;
	}

	private bool pushBox(Vector2 newPosition, Vector2 direction)
	{
		var box = Physics2D.OverlapPoint(newPosition,_boxLayer).gameObject;
		return box.GetComponent<MovingObject>().boxMove(direction);
	}

	private bool boxMove(Vector2 direction)
	{
		var newPosition = _rb2d.position + direction;

		if (wallAt(newPosition)) return false;
		if (boxAt(newPosition)) return false;
		
		_rb2d.MovePosition(_rb2d.position + direction);
		return true;
	}

	private bool boxAt(Vector2 newPosition)
	{
		return Physics2D.OverlapPoint(newPosition,_boxLayer) != null;
	} 
	
	private bool wallAt(Vector2 newPosition)
	{
		return Physics2D.OverlapPoint(newPosition, _wallLayer) != null;
	}

	private IEnumerator moveRoutine(Vector3 end)
	{
		var sqrtRemainingDistance = (transform.position - end).sqrMagnitude;
		while (sqrtRemainingDistance > float.Epsilon)
		{
			var newPosition = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
			_rb2d.MovePosition(newPosition);
			sqrtRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
	}
	
	
}
