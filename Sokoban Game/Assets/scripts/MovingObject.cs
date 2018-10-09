using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=fURWEzpNPL8
public class MovingObject : MonoBehaviour
{

	private Rigidbody2D _rb2d;
	private float inverseMoveTime;
	
	private void Start ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / .5f;
	}

	public bool move(int x,int y)
	{
		_rb2d.MovePosition(_rb2d.position+new Vector2(x,y));
		return true;
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
