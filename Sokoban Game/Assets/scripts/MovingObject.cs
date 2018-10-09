using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=fURWEzpNPL8
public class MovingObject : MonoBehaviour
{

	private Rigidbody2D _rb2d;
	private float inverseMoveTime;
	private bool canMove;
	private Vector2 _lastPos;
	
	private void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / .5f;
		canMove = true;
	}

	public bool move(Vector2 newPosition)
	{
		if (!canMove) return false;

		_lastPos = _rb2d.position;
		_rb2d.MovePosition(_rb2d.position + newPosition);
		StartCoroutine(moveTimer());
		
		return true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Wall"))
		{
			_rb2d.position = _lastPos;
		}	
	}

	private IEnumerator moveTimer()
	{
		canMove = false;
		yield return new WaitForSeconds(1f);
		canMove = true;
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
