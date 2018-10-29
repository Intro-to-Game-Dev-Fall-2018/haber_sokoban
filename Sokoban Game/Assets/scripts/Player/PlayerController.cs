using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovingObject))]
public class PlayerController : MonoBehaviour
{

	[SerializeField] private PlayerAnimator _animator;
	
	private MovingObject _motor;
	private bool _canMove;

	public static UnityEvent PlayerMoves;
	
	private void Start()
	{
		_motor = GetComponent<MovingObject>();
		_canMove = true;
		if (PlayerMoves == null) PlayerMoves = new UnityEvent();
	}

	private void move(int x,int y)
	{
		if (!_canMove) return;
		
		var direction = new Vector2(x,y);
		var result = _motor.move(direction);

		if (result == MOVE.FAIL )
			return;
		
		PlayerMoves.Invoke();
		_animator.Advance(result,direction);

		GameManager.Instance.State.Move();
		StartCoroutine(moveTimer());
	}

	private void Update()
	{
		var x = (int) Input.GetAxis("Horizontal");
		var y = (int) Input.GetAxis("Vertical");

		if (y != 0)
			x = 0;

		if (x != 0 || y != 0)
			move(x,y);
	}
	
	private IEnumerator moveTimer()
	{
		_canMove = false;
		yield return new WaitForSeconds(GameManager.Instance.Settings.moveTime);
		_canMove = true;
	}
	
}
