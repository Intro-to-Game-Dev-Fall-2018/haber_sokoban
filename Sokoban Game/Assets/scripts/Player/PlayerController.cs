using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private PlayerAnimator _animator;
	
	private MovingObject _motor;
	private bool _canMove;
	private bool _canUndo;


	private void Start()
	{
		_motor = GetComponent<MovingObject>();
		_canMove = true;
		_canUndo = true;
		GuiManager.OnPause.AddListener(Disable);
		GuiManager.OnUnPause.AddListener(Enable);
	}

	private void Update()
	{
		if (!_canMove) return;

		var x = (int) Input.GetAxis("Horizontal");
		var y = (int) Input.GetAxis("Vertical");

		if (y != 0)
			x = 0;

		if (x != 0 || y != 0)
		{
			Move(x,y);
			return;
		}
		
		if (Input.GetButton("Undo"))
			Undo();
	
	}
	
	private void Move(int x,int y)
	{
		if (!_canMove) return;
		
		var direction = new Vector2(x,y);
		var result = _motor.move(direction);

		if (result == MOVE.FAIL )
			return;
		
		_animator.Advance(result,direction);

		GameManager.Instance.State.Move();
		StartCoroutine(MoveTimer());
	}

	private void Undo()
	{
		if (!_canUndo) return;
		
		GameManager.Instance.Undo();
		StartCoroutine(MoveTimer());
	}

	private void Disable()
	{
		_canMove = false;
		GameManager.Instance.Undo();
		StartCoroutine(MoveTimer());
	}

	private void Enable()
	{
		_canMove = true;
	}
	
	private IEnumerator MoveTimer()
	{
		_canMove = false;
		_canUndo = false;
		yield return new WaitForSeconds(GameData.Settings.moveTime);
		_canMove = true;
		yield return  new WaitForEndOfFrame();
		_canUndo = true;
	}
	
}
