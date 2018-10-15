using System.Collections;
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
	private bool _moving;
	
	private void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / GameManager.Instance.Settings.moveTime;
	}
	
	public bool move(Vector2 direction)
	{
		if (_moving) return false;
		var newPosition = _rb2d.position + direction;
		
		if (wallAt(newPosition)) return false;
		if (boxAt(newPosition))
			if (!pushBox(newPosition, direction))
				return false;
			
		StartCoroutine(moveRoutine(_rb2d.position + direction));
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
		
		StartCoroutine(moveRoutine(_rb2d.position + direction));
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
		if (_moving) yield break;
		_moving = true;
		var sqrtRemainingDistance = (transform.position - end).sqrMagnitude;
		
		while (sqrtRemainingDistance > float.Epsilon)
		{
			var newPosition = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
			_rb2d.MovePosition(newPosition);
			sqrtRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
		
		_rb2d.MovePosition(end);
		_moving = false;
	}
	
	
}
