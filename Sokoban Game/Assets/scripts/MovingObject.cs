using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=fURWEzpNPL8
public class MovingObject : MonoBehaviour
{

	private Rigidbody2D _rb2d;
	private float inverseMoveTime;
	private bool canMove;
	
	private void Awake ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / .5f;
		canMove = true;
	}

	public bool move(int x,int y)
	{
		if (!canMove) return false;
		
		_rb2d.MovePosition(new Vector2(_rb2d.position.x+x,_rb2d.position.y+y));
		StartCoroutine(moveTimer());
		
		return true;
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
