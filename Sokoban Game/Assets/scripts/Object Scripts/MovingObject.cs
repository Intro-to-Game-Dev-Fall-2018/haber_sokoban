using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public enum MOVE
{
	FAIL = 0,
	WALK = 1,
	PUSH = 2
}

//https://www.youtube.com/watch?v=fURWEzpNPL8
public class MovingObject : MonoBehaviour
{

	[Header("Wall Filter")]
	[SerializeField] private LayerMask _wallLayer;
	[SerializeField] private LayerMask _boxLayer;
	[SerializeField] private bool isPlayer;
	
	private Rigidbody2D _rb2d;
	private float inverseMoveTime;
	private bool _moving;

	private Dictionary<int,Vector2> _moves;
	
	private void Start ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / GameData.Settings.moveTime;
		_moves = new Dictionary<int, Vector2>();
	}

	public void Undo(int move)
	{
		if (!_moves.ContainsKey(move)) return;
		
		var pos = _moves[move];
		_rb2d.MovePosition(pos);
		_moves.Remove(move);
	}
	
	public MOVE move(Vector2 direction)
	{
		if (_moving) return MOVE.FAIL;
		
		var push = false;
		var newPosition = _rb2d.position + direction;
		
		if (wallAt(newPosition)) return MOVE.FAIL;
		
		if (boxAt(newPosition))
			if (!isPlayer)
				return MOVE.FAIL;
			else if (pushBox(newPosition, direction)==MOVE.FAIL)
				return MOVE.FAIL;
			else
				push = true; 
		
		_moves.Add(GameManager.Instance.State.moves,_rb2d.position);
		
		StartCoroutine(moveRoutine(newPosition));
		
		return push ? MOVE.PUSH : MOVE.WALK;
	}

	private MOVE pushBox(Vector2 newPosition, Vector2 direction)
	{
		var box = Physics2D.OverlapPoint(newPosition,_boxLayer).gameObject;
		return box.GetComponent<MovingObject>().move(direction);
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
